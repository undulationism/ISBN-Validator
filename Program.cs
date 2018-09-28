using System;

namespace ISBN_Validator {
    class Program {
        static void Main (string[] args) {
            //String input;
            //String sanitized;

            //Console.WriteLine ("ISBN zur Prüfung eingeben und mit Enter bestätigen:");
            //input = Console.ReadLine ();
            //foreach (char c in input) {
                //if (Char.IsNumber(c));
            //} 
            Console.WriteLine(Isbn10("173483927"));
            Console.WriteLine(Isbn10("857391042"));
            Console.WriteLine(Isbn10("957391042"));

            

        }

        static String Isbn10 (String incomplete) {
            int parity = 0;
            String isbn;
            for (int i = 0; i < 9; i++) {
                parity = parity + Convert.ToInt32(Convert.ToString(incomplete[i])) * (i+1);
            }
            parity = parity % 11;
            if (parity == 10) {
                isbn = incomplete + "X";
            } else {
                isbn = incomplete + Convert.ToString(parity);
            }
            return isbn;
        }
    }
}