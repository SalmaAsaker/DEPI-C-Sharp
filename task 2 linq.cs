// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.IO;

// namespace LINQ_Assignment
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {

         // ===============================
         // linq - restriction operators
         // ===============================

         // 1
         // find all products that are out of stock.
         // var result1 = listgenerators.productlist
         //                 .where(p => p.unitsinstock == 0);

         // -----


         // 2
         // find all products that are in stock and cost more than 3.00 per unit.
         // var result2 = listgenerators.productlist
         //                 .where(p => p.unitsinstock > 0 && p.unitprice > 3.00m);

         // -----


         // 3
         // returns digits whose name is shorter than their value.
         // string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         // var result3 = digits
         //                 .where((d, index) => d.length < index);


         // ===============================
         // linq - element operators
         // ===============================

         // 4
         // get first product out of stock
         // var result4 = listgenerators.productlist
         //                 .first(p => p.unitsinstock == 0);

         // -----


         // 5
         // return first product whose price > 1000 or null
         // var result5 = listgenerators.productlist
         //                 .firstordefault(p => p.unitprice > 1000);

         // -----


         // 6
         // retrieve second number greater than 5
         // int[] arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
         // var result6 = arr1
         //                 .where(n => n > 5)
         //                 .skip(1)
         //                 .first();


         // ===============================
         // linq - aggregate operators
         // ===============================

         // 7
         // count odd numbers
         // int[] arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
         // var result7 = arr2.count(n => n % 2 == 1);

         // -----


         // 8
         // list customers and how many orders each has
         // var result8 = listgenerators.customerlist
         //                 .select(c => new
         //                 {
         //                     c.customername,
         //                     orderscount = c.orders.count()
         //                 });

         // -----


         // 9
         // categories and number of products
         // var result9 = listgenerators.productlist
         //                 .groupby(p => p.category)
         //                 .select(g => new
         //                 {
         //                     category = g.key,
         //                     count = g.count()
         //                 });

         // -----


         // 10
         // total of numbers
         // var result10 = arr2.sum();

         // -----


         // 11
         // total units in stock for each category
         // var result11 = listgenerators.productlist
         //                 .groupby(p => p.category)
         //                 .select(g => new
         //                 {
         //                     category = g.key,
         //                     totalunits = g.sum(p => p.unitsinstock)
         //                 });

         // -----


         // 12
         // cheapest price in each category
         // var result12 = listgenerators.productlist
         //                 .groupby(p => p.category)
         //                 .select(g => new
         //                 {
         //                     category = g.key,
         //                     minprice = g.min(p => p.unitprice)
         //                 });

         // -----


         // 13
         // most expensive price in each category
         // var result13 = listgenerators.productlist
         //                 .groupby(p => p.category)
         //                 .select(g => new
         //                 {
         //                     category = g.key,
         //                     maxprice = g.max(p => p.unitprice)
         //                 });

         // ===============================
         // linq - ordering operators
         // ===============================

         // 14
         // sort products by name
         // var result14 = listgenerators.productlist
         //                 .orderby(p => p.productname);

         // -----


         // 15
         // case insensitive sort
         // string[] words = { "apple", "abacus", "branch", "blueberry", "clover", "cherry" };
         // var result15 = words
         //                 .orderby(w => w, stringcomparer.ordinalignorecase);

         // -----


         // 16
         // sort products by unitsinstock descending
         // var result16 = listgenerators.productlist
         //                 .orderbydescending(p => p.unitsinstock);


         // ===============================
         // linq - partitioning operators
         // ===============================

         // 17
         // first 3 orders from washington
         // var result17 = listgenerators.customerlist
         //                 .where(c => c.region == "wa")
         //                 .selectmany(c => c.orders)
         //                 .take(3);

         // -----


         // 18
         // all but first 2 orders from washington
         // var result18 = listgenerators.customerlist
         //                 .where(c => c.region == "wa")
         //                 .selectmany(c => c.orders)
         //                 .skip(2);


         // ===============================
         // linq - quantifiers
         // ===============================

         // 19
         // any word contains 'ei'
         // string[] dictionary = file.readalllines("dictionary_english.txt");
         // var result19 = dictionary.any(w => w.contains("ei"));

         // -----


         // 20
         // categories that have at least one product out of stock
         // var result20 = listgenerators.productlist
         //                 .groupby(p => p.category)
         //                 .where(g => g.any(p => p.unitsinstock == 0));

     //    }
   //  }
// }