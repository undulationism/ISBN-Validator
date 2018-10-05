using System;

namespace ISBN_Validator {
    class Program {
        static void Main (string[] args) {            
            System.Console.WriteLine(AddCheckDigitToIsbn13("978383621997"));
            System.Console.WriteLine(AddCheckDigitToIsbn13("978245362733"));
        }

        static String AddCheckDigitToIsbn10 (String isbnWithoutCheckDigit) {
            int checkSum = 0;
            String isbn;
            for (int i = 0; i < 9; i++) {
                checkSum = checkSum + Convert.ToInt32(Convert.ToString(isbnWithoutCheckDigit[i])) * (i+1);
            }
            checkSum = checkSum % 11;
            if (checkSum == 10) {
                isbn = isbnWithoutCheckDigit + "X";
            } else {
                isbn = isbnWithoutCheckDigit + Convert.ToString(checkSum);
            }
            return isbn;
        }

        static String AddCheckDigitToIsbn13 (String isbnWithoutCheckDigit) {
            int checkSum = 0;
            int checkDigit;
            int gewicht = 1;

            for (int i = 0; i < 12; i++) {
                checkSum = checkSum + Convert.ToInt32(Convert.ToString(isbnWithoutCheckDigit[i])) * (gewicht);
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