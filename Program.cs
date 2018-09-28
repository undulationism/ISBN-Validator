using System;

namespace ISBN_Validator {
    class Program {
        static void Main (string[] args) {            

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
    }
}