using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Backend
{
    public class Validation
    {
        public static bool hasValidationErrors(System.Windows.Forms.Control.ControlCollection controls)
        {
            bool hasError = false;

            // Now we need to loop through the controls and deterime if any of them have errors
            foreach (Control control in controls)
            {
                // check the control and see what it returns
                bool validControl = IsValid(control);
                // If it's not valid then set the flag and keep going.  We want to get through all
                // the validators so they will display on the screen if errorProviders were used.
                if (!validControl)
                    hasError = true;

                // If its a container control then it may have children that need to be checked
                if (control.HasChildren)
                {
                    if (hasValidationErrors(control.Controls))
                        hasError = true;
                }
            }
            return hasError;
        }

        // Here, let's determine if the control has a validating method attached to it
        // and if it does, let's execute it and return the result
        private static Boolean IsValid(object eventSource)
        {
            string name = "EventValidating";

            Type targetType = eventSource.GetType();

            do
            {
                FieldInfo[] fields = targetType.GetFields(
                        BindingFlags.Static |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic);

                foreach (FieldInfo field in fields)
                {
                    if (field.Name == name)
                    {
                        EventHandlerList eventHandlers = ((EventHandlerList)(eventSource.GetType().GetProperty("Events",
                            (BindingFlags.FlattenHierarchy |
                            (BindingFlags.NonPublic | BindingFlags.Instance))).GetValue(eventSource, null)));

                        Delegate d = eventHandlers[field.GetValue(eventSource)];

                        if ((!(d == null)))
                        {
                            Delegate[] subscribers = d.GetInvocationList();

                            // ok we found the validation event,  let's get the event method and call it
                            foreach (Delegate d1 in subscribers)
                            {
                                // create the parameters
                                object sender = eventSource;
                                CancelEventArgs eventArgs = new CancelEventArgs();
                                eventArgs.Cancel = false;
                                object[] parameters = new object[2];
                                parameters[0] = sender;
                                parameters[1] = eventArgs;
                                // call the method
                                d1.DynamicInvoke(parameters);
                                // if the validation failed we need to return that failure
                                if (eventArgs.Cancel)
                                    return false;
                                else
                                    return true;
                            }
                        }
                    }
                }

                targetType = targetType.BaseType;

            } while (targetType != null);

            return true;
        }

        public static Boolean IsInt (System.Object Expression)
        {
            if (Expression.ToString() == string.Empty)
                return true;
            if(Expression is DateTime)
                return false;

            if(Expression is Int16 || Expression is Int32 || Expression is Int64)
                return true;
  
            try
            {
                if(Expression is string)
                    Int32.Parse(Expression as string);
                else
                    Int32.Parse(Expression.ToString());
                    return true;
             } catch {} // just dismiss errors but return false
                
            return false;
        }

        public static Boolean IsByte(Object Expression)
        {
            if (Expression.ToString() == string.Empty)
                return true;
            if (Expression is DateTime)
                return false;

            if (Expression is Byte)
                return true;

            try
            {
                if (Expression is string)
                    Byte.Parse(Expression as string);
                else
                    Byte.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false

            return false;
        }
        public static Boolean IsDouble(Object Expression)
        {

            if (Expression.ToString() == string.Empty)
                return true;
            if (Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false

            return false;
        }
        public static Boolean IsDecimal(Object Expression)
        {
            if (Expression.ToString() == string.Empty)
                return true;
            if (Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false

            return false;
        }

        public static string CheckRRNumberValidity(string input)
        {
            if (input != null)
            {
                string message = "";

                Regex nonAllowedCharacters = new Regex(@"[^0-9. -]");
                Regex nonNumeric = new Regex(@"[^0-9]");

                string rrnumber = input;

                if (nonAllowedCharacters.IsMatch(rrnumber))
                    return "Non allowed character";
                else
                {
                    //STRIP THE NUMBER FROM ALL NON NUMERIC CHARS
                    rrnumber = nonNumeric.Replace(rrnumber, "");

                    //LENGTH MUST BE 11 DIGITS
                    if (rrnumber.Length != 11)
                        return "Length != 11";
                    else
                    {

                        try
                        {
                            bool birthDateOK = false;
                            bool counterOK = false;
                            bool controlOK = false;

                            bool born2kOrLater = false;

                            string gender = "(unknown)";

                            //FIRST 6 DIGITS ARE BIRTHDATE IN FORMAT YYMMDD
                            string birthDatePart = rrnumber.Substring(0, 6);

                            //NEXT 3 ARE COUNTER
                            string counterPart = rrnumber.Substring(6, 3);

                            //LAST 2 ARE CONTROLNUMBER
                            string controlPart = rrnumber.Substring(9, 2);

                            /* 1. CONTROL NUMBER CHECKING */
                            /******************************/

                            //CALCULATE CONTROLNUMER (= MOD 97 OF FIRST 9 DIGITS)
                            int calculatedControl = 97 - (int)(Int64.Parse(birthDatePart + counterPart) % 97);

                            if (calculatedControl != Int32.Parse(controlPart))
                            {
                                /* IF THE CALCULATED CONTROL PART IS DIFFERENT THAN THE ONE IN THE INPUTSTRING
                                 * ADD A "2" IN FRONT OF THE BIRTHDATEPART AND RECALCULATE. THIS WAS INTRODUCED TO
                                 * ALLOW BIRTHDATES OF YEAR 2000 AND LATER
                                */

                                calculatedControl = 97 - (int)(Int64.Parse("2" + birthDatePart + counterPart) % 97);

                                if (calculatedControl != Int32.Parse(controlPart))
                                {
                                    /* THE CALCULATION STILL DOESN'T MATCH THE CONTROLNUMER, SO THIS IS AN INVALID
                                     * REGISTRY NUMBER
                                    */

                                    controlOK = false;
                                }
                                else
                                {
                                    born2kOrLater = true;
                                    controlOK = true;
                                }
                            }
                            else
                                controlOK = true;

                            /* 2. BIRTHDATE CHECKING */
                            /*************************/

                            string d = birthDatePart;
                            //BUILD THE BIRTHDATE TO CHECK
                            if (born2kOrLater == true)
                                d = "20" + birthDatePart;
                            else
                                d = "19" + birthDatePart;
                            //END BUILD

                            string format = "yyyyMMdd";
                            DateTime birthDate;

                            birthDateOK = DateTime.TryParseExact(d, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out birthDate);
                            Console.WriteLine(birthDate.ToString("dd/MM/yyyy"));

                            /* 3. COUNTER CHECKING */
                            /***********************/

                            /* COUNTERPART MUST BE BETWEEN 001 AND 997
                             * EVEN FOR FEMALE
                             * ODD FOR MALE
                            */
                            int counter = Int32.Parse(counterPart);

                            if (counter < 1 || counter > 997)
                                counterOK = false;
                            else if (counter % 2 == 0) //EVEN
                            {
                                counterOK = true;
                                gender = "F"; //FEMALE
                            }
                            else
                            {
                                counterOK = true;
                                gender = "M"; //MALE
                            }

                            /* 4. RETURN GENDER OR MESSAGE */
                            /*******************************/

                            if (!birthDateOK)
                                message += "Invalid birthdate;";
                            if (!counterOK)
                                message += "Invalid counter;";
                            if (!controlOK)
                                message += "Invalid control number;";

                            if (!message.Equals("")) //THERE ARE ERRORS
                            {
                                if (message.EndsWith(";"))
                                    message = message.Substring(0, message.Length - 1);

                                return message;
                            }
                            else //IF GETTING HERE, NUMBER SHOULD BE CORRECT AND GENDER FILLED IN
                                return gender;
                        }
                        catch (Exception)
                        {
                            return "Exception";
                        }
                    }
                }
            }
            else
            {
                return "isnull";
            }
        }

        public static Boolean IsBankrekeningnummer(string input)
        {
            try
            {
                string nummer = input.Replace("-", "");
                decimal basisgetal = decimal.Parse(nummer.Substring(0, 10));
                decimal controlegetal = decimal.Parse(nummer.Substring(10, 2));

                if (basisgetal % 97 != controlegetal)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean IsBTWNummer(string input)
        {
           try
            {
                if (input.Replace(" ", "") == "-")
                {
                    return true;
                }
                string nummer = input.Replace("-", "");

                //403227515

                decimal basisgetal = decimal.Parse(nummer.Substring(3, 7));
                decimal controlegetal = decimal.Parse(nummer.Substring(10, 2));
                decimal rest = basisgetal % 97;

                if (97 - rest != controlegetal)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
