﻿using System.Collections.Generic;

namespace TestSamples {
    // Ожидаемый результат:
    // * Строки с символом "@" помещаются в конец коллекции, сортируются в алфавитном порядке;
    // * Строки без символа "@" помещаются в начало коллекции, также сортируются в алфавитном порядке.
    // Например: [ "b@", "b", "a", "c", "@", "a@" ] =>  [ "a", "b", "c", "@", "a@", "b@" ]
    public class TestComparer : IComparer<string> {
        public int Compare(string x, string y) {
            bool xWithAt = x.Contains("@");
            bool yWithAt = y.Contains("@");
            if (xWithAt && !yWithAt)
                return 1;
            if (!xWithAt && yWithAt)
                return -1;
            return x.CompareTo(y);
        }
    }
}