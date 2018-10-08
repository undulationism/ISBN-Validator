using System;

namespace ISBN_Validator {
    class ISBN {
        static void Main (string[] args) {
            while (true) {
                string test = Console.ReadLine ();
                test = removeInvalidChars (test);
                if (test.Length == 10) {
                    Console.WriteLine (test.Equals (AddCheckDigitToIsbn10 (test.Substring (0, 9))));
                }
                if (test.Length == 13) {
                    Console.WriteLine (test.Equals (AddCheckDigitToIsbn13 (test.Substring (0, 12))));
                }
                if (test.Length == 9) {
                    Console.WriteLine (AddCheckDigitToIsbn10 (test));
                }
                if (test.Length == 12) {
                    Console.WriteLine (AddCheckDigitToIsbn13 (test));
                }
            }
        }

        static string removeInvalidChars (String input_string) {
            string onlyDigitsAndX = "";
            string isbn = "";
            input_string = input_string.ToUpper ();

            foreach (char c in input_string) {
                if (System.Char.IsDigit (c) || c == 'X') {
                    onlyDigitsAndX += c;
                }
            }

            if (onlyDigitsAndX.Length < 1) {
                return onlyDigitsAndX;
            }

            foreach (char c in onlyDigitsAndX.Substring (0, onlyDigitsAndX.Length - 1)) {
                if (System.Char.IsDigit (c)) {
                    isbn += c;
                }
            }
            isbn += onlyDigitsAndX[onlyDigitsAndX.Length - 1];
            if (isbn.Length == 13) {
                if (isbn[12] == 'X') {
                    return isbn.Substring (0, 12);
                }
            }
            return isbn;
        }

        static String AddCheckDigitToIsbn10 (String isbnWithoutCheckDigit) {
            int checkSum = 0;
            String isbn;
            for (int i = 0; i < 9; i++) {
                checkSum = checkSum + Convert.ToInt32 (Convert.ToString (isbnWithoutCheckDigit[i])) * (i + 1);
            }
            checkSum = checkSum % 11;
            if (checkSum == 10) {
                isbn = isbnWithoutCheckDigit + "X";
            } else {
                isbn = isbnWithoutCheckDigit + Convert.ToString (checkSum);
            }
            return isbn;
        }

        static String AddCheckDigitToIsbn13 (String isbnWithoutCheckDigit) {
            int checkSum = 0;
            int checkDigit;
            int gewicht = 1;

            for (int i = 0; i < 12; i++) {
                checkSum = checkSum + Convert.ToInt32 (Convert.ToString (isbnWithoutCheckDigit[i])) * (gewicht);
                if (gewicht == 1) {
                    gewicht = 3;
                } else {
                    gewicht = 1;
                }
            }
            checkDigit = 10 - checkSum % 10;

            return isbnWithoutCheckDigit + checkDigit;
        }
    }
}