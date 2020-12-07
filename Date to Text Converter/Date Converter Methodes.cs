using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Date_to_Text_Converter
{
    class Date_Converter_Methodes
    {
        public bool validation(string date,string lang,string acc,out int err_id,out string err_message)
        {
            date = date.Trim();
            lang = lang.Trim();
            acc = acc.Trim();
            if (Date_Validation(date,out err_id,out err_message))
            {
                if (language_validation(lang,out err_id,out err_message))
                {
                    if(lang =="EN")
                    {
                        if(Accent_Validation(acc,out err_id,out err_message))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// defines whether the language (that the number will be convrted in it's format) is valid or invalid
        /// ,save error message incase error occured & save id for that message.
        /// /// err_id : err_message
        ///    0   | "success"
        ///    1   | "undefined language"
        /// </summary>
        /// <param name="lang">string carry the indicator of the language</param>
        /// <param name="err_id">int id of error type occured</param>
        /// <param name="err_message">string save message explain that type of error</param>
        /// <returns>returns true the indicator of language is right</returns>
        public bool language_validation(string lang, out int err_id, out string err_message)
        {
            if (lang == "AR" || lang == "EN")//Check whther the string carry defined indicator
            {
                err_id = 0;
                err_message = "success";//set error id of not occuring error.
                return true;//set message of success for validation.
            }
            else
            {
                if (lang.Length == 0)
                {
                    err_id = 11;//set id of the error.
                    err_message = "language field is empty";// set error message describe the error type.
                    return false;
                }
                err_id = 12;//set id of the error.
                err_message = "undefined language";// set error message describe the error type.
                return false;

            }
        }
        public bool Accent_Validation(string accent, out int err_id, out string err_message)
        {
            if (accent == "UK" || accent == "US")
            {
                err_id = 0;
                err_message = "Success.";
                return true;
            }
            else
            {
                if (accent.Length == 0)
                {
                    err_id = 13;//set id of the error.
                    err_message = "accent field is empty";// set error message describe the error type.
                    return false;
                }
                err_id = 14;//set id of the error.
                err_message = "undefined accent";// set error message describe the error type.
                return false;
            }
        }
        public bool Date_Validation(string date,out int err_id,out string err_message)
        {
            if (date.Length > 0 && date.Length < 11)
            {
                int slash_count = 0, dash_count = 0;
                foreach(char factor in date)
                {
                    if((factor >= '0' && factor <= '9'))
                    {
                        continue;
                    }
                    else if(factor == '-')
                    {
                        dash_count++;
                        continue;
                    }
                    else if(factor == '/')
                    {
                        slash_count++;
                        continue;
                    }
                    else
                    {
                        err_id = 3;
                        err_message = "Wrong inputted char.";
                        return false;
                    }
                }
                Regex RX = new Regex(@"^\d{1,2}(-|\/)\d{1,2}(-|\/)\d{4}$");
                if(RX.IsMatch(date))
                {
                    string[] DateParts = new string[3];
                    if (slash_count == 1 && dash_count == 1)
                    {
                        string[] FirstSepratorSides = new string[2];
                        string[] SecondPartSepratorSides = new string[2];
                        if (Array.IndexOf(date.Split('/')[0].ToCharArray(), '-') == -1)
                        {
                            FirstSepratorSides = date.Split('/');
                            SecondPartSepratorSides = FirstSepratorSides[1].Split('-');
                        }
                        else
                        {
                            FirstSepratorSides = date.Split('-');
                            SecondPartSepratorSides = FirstSepratorSides[1].Split('/');
                        }
                        DateParts[0] = FirstSepratorSides[0];
                        DateParts[1] = SecondPartSepratorSides[0];
                        DateParts[2] = SecondPartSepratorSides[1];
                    }
                    else
                    {
                        if (date.Split('/').Length == 3)
                            DateParts = date.Split('/');
                        else
                            DateParts = date.Split('-');
                    }
                    if(Convert.ToInt32(DateParts[2]) > 1599)
                    {
                        if(Convert.ToInt32(DateParts[0]) == 31)
                        {
                            if(InRange(Convert.ToInt32(DateParts[1]),1,3,5,7,8,10,12))
                            {
                                err_id = 0;
                                err_message = "Success.";
                                return true;
                            }
                            else if(Convert.ToInt32(DateParts[1]) > 0 && Convert.ToInt32(DateParts[1]) < 13)
                            {
                                err_id = 6;
                                err_message = "The Month Contain less than 31 day.";
                                return false;
                            }
                            else
                            {
                                err_id = 7;
                                err_message = "Their's no such month.";
                                return false;
                            }
                        }
                        else if(Convert.ToInt32(DateParts[0]) == 30)
                        {
                            if (Convert.ToInt32(DateParts[1]) == 2)
                            {
                                err_id = 8;
                                err_message = "The Month Contain less than 30 day.";
                                return false;
                            }
                            else if (Convert.ToInt32(DateParts[1]) > 0 && Convert.ToInt32(DateParts[1]) < 13)
                            {
                                err_id = 0;
                                err_message = "Success.";
                                return true;
                            }
                            else
                            {
                                err_id = 7;
                                err_message = "Their's no such month.";
                                return false;
                            }
                        }
                        else if(Convert.ToInt32(DateParts[0]) == 29)
                        {
                            if(Convert.ToInt32(DateParts[1]) == 2)
                            {
                                if(Convert.ToInt32(DateParts[2]) % 4 == 0)
                                {
                                    err_id = 0;
                                    err_message = "Success.";
                                    return true;
                                }
                                else
                                {
                                    err_id = 10;
                                    err_message = "February in this year is 28 days only";
                                    return false;
                                }
                            }
                            else if (Convert.ToInt32(DateParts[1]) > 0 && Convert.ToInt32(DateParts[1]) < 13)
                            {
                                err_id = 0;
                                err_message = "Success.";
                                return true;
                            }
                            else
                            {
                                err_id = 7;
                                err_message = "Their's no such month.";
                                return false;
                            }
                        }
                        else if(Convert.ToInt32(DateParts[0]) < 29 && Convert.ToInt32(DateParts[0]) != 0)
                        {
                            if (Convert.ToInt32(DateParts[1]) > 0 && Convert.ToInt32(DateParts[1]) < 13)
                            {
                                err_id = 0;
                                err_message = "Success.";
                                return true;
                            }
                            else
                            {
                                err_id = 7;
                                err_message = "Their's no such month.";
                                return false;
                            }
                        }
                        else
                        {
                            err_id = 9;
                            err_message = "Their's no such Day.";
                            return false;
                        }
                    }
                    else
                    {
                        err_id = 5;
                        err_message = "Year value is too small.";
                        return false;
                    }

                }
                else
                {
                    err_id = 4;
                    err_message = "Invalid Format.";
                    return false;
                }

            }
            else
            {
                if (date.Length == 0)
                {
                    err_id = 1;
                    err_message = "date field is empty.";
                    return false;
                }
                err_id = 2;
                err_message = "Length is out of range.";
                return false;
            }
        }
        public bool InRange(int value,params int [] Range)
        {
            bool WithinRange = false;
            foreach (int range in Range)
            {
                if (value == range)
                {
                    WithinRange = true;
                    break;
                }
            }
            return WithinRange;
        }
        public string DateConverter(string Date,string lang,string accent = "UK")
        {
            int err_id;
            string err_message;
            Date = Date.Trim();
            lang = lang.Trim();
            accent = accent.Trim();
            if (validation(Date, lang, accent, out err_id, out err_message))
            {
                if (lang == "EN")
                    return DateConverter_En(Convert.ToDateTime(Date), accent);
                else
                    return DateConverter_Ar(Convert.ToDateTime(Date));
            }
            else
            {
                return "Error : Id : " + err_id + " : " + err_message;
            }
        }
        public string DateConverter_En(DateTime Date,string acc)
        {
            string[] months ={"January","February","March","April","May","June","July","August","September","October","November","December"};
            string day = DayConverter_En(Date.Day), month = months[Date.Month - 1].ToString();
            if (acc == "UK")
                return "The " + day + " of " + month + " " + integer_converter_En(Date.Year);
            else
                return month + " " + day + " " + integer_converter_En(Date.Year); 

        }
        /// <summary>
        /// converts a decimal number that is integral only into a text in english
        /// </summary>
        /// <param name="integer">decimal carries the value of the integer that will be converted</param>
        /// <returns>returns the equivalent text for the integer number</returns>
        public string integer_converter_En(decimal integer)
        {
            if (integer == 0)// check if the number is 0.
                return "";// returns nothing.
            else
            {
                string text = "";//set string that the value of each three digits of the number will accumlate in it.
                if ((long)integer / 1000000000 > 0)//check whether the 3 digits (that describe the billion value) there value not zero.
                {
                    text += integer_converter_En((long)integer / 1000000000) + " Billion ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word billion.
                    integer %= 1000000000;//remove from the integer the three digit of billion level.
                }
                if ((int)integer / 1000000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000000) + " Million ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word Milion.
                    integer %= 1000000;//remove from the integer the three digit of Million level.
                }
                if ((int)integer / 1000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000) + " Thousand ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word thousand.
                    integer %= 1000;//remove from the integer the three digit of thousand level.
                }
                if ((int)integer / 100 > 0)//check whether the hundered digit isn't zero.
                {
                    text += integer_converter_En((int)integer / 100) + " hundered ";
                    //add for text the text conversion of the hundered digit (but starts as unit) and add word hundered.
                    integer %= 100;//remove from the integer the hundered digit.
                }
                if (integer == 0)//check whether the units & tenth digits summation value is zero.
                    return text;//return the text reulted from digits from hundered to billion.

                string[] units_tenth = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                //intialize array carries the name of numbers less than twenty.
                string[] tenth = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                //intialize array that carry the names of tenth digits except that first the one as theeach combination of it with units gives specified name.
                if (integer < 20)//check whether the integer value is less than twenty.
                {
                    text += units_tenth[(int)integer];//add the name of the number that less than 20 and it's value is integer.
                }
                else
                {
                    text += tenth[(int)integer / 10];//get the value of the tenth digit only and add it's name as a tenth.
                    if (integer % 10 > 0)//check whether the units digit isn't zero.
                        text += "-" + integer_converter_En(integer % 10);//add dash then the name of the digit in units digit.
                }


                return text;

            }
        }
        public string DayConverter_En(int Day)
        {
            
            if (Day < 11)
            {
                string[] tenth = new string[]
                {"First",
                "Second",
                "Third",
                "Fourth",
                "Fifth",
                "Sixth",
                "Seventh",
                "Eighth",
                "Ninth",
                "Tenth"};
                return tenth[Day - 1];
            }
            else if(Day / 10 == 1)
            {
                
                if (Day == 12)
                    return "Twelfth";
                else
                    return integer_converter_En(Day) + "th" ;
            }
            else if(Day % 10 == 0)
            {
                if (Day / 10 == 2)
                    return "Twentieth";
                else
                    return "Thirtieth";
            }
            else
            {
                if (Day / 10 == 2)
                    return "Twenty-" + DayConverter_En(Day % 10);
                else
                    return "Thirty-First";
            }

        }
        public string DateConverter_Ar(DateTime Date)
        {
            Value_to_Text_Converter.Value_To_Text_Methodes int_converter = new Value_to_Text_Converter.Value_To_Text_Methodes();
            string[] months = new string[]
            {"يانير",
            "فبراير",
            "مارس",
            "ابريل",
            "مايو",
            "يونيو",
            "يوليو",
            "أغسطس",
            "سبتمبر",
            "أكتوبر",
            "نوفمبر",
            "ديسمبر"};
            return "اليوم " + DayConverter_Ar(Date.Day) + " من شهر " + months[Date.Month - 1] + " للعام " + int_converter.integer_converter_Ar(Date.Year) + " الميلادى";

        }
        public string DayConverter_Ar(int Day)
        {
            if (Day < 11)
            {
                string[] tenth = new string[]
                {"الأول",
                "الثانى",
                "الثالث",
                "الرابع",
                "الخامس",
                "السادس",
                "السابع",
                "الثامن",
                "التاسع",
                "العاشر"};
                return tenth[Day - 1];
            }
            else if (Day / 10 == 1)
            {

                if (Day == 11)
                    return "الحادى عشر";
                else
                    return DayConverter_Ar(Day % 10) + " عشر" ;
            }
            else if (Day % 10 == 0)
            {
                if (Day / 10 == 2)
                    return "العشرون";
                else
                    return "الثلاثون";
            }
            else
            {
                if (Day / 10 == 2)
                {
                    if (Day == 21)
                        return "الحادى و العشرون";
                    else
                        return DayConverter_Ar(Day % 10) + " و العشرون";
                }
                else
                    return "الحادى و الثلاثون";
            }
        }
    }
}
