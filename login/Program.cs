using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;


namespace login
{
    class Program
    {
        private const string _patternIph = @"input type=""hidden"" name=""ip_h"" value=""\w{18}""";
        private const string _patternLgh = @"input type=""hidden"" name=""lg_h"" value=""\w{18}""";
        static void Main(string[] args)
        {
            Console.Write("Login:");
            var login = Console.ReadLine();
            Console.Write("Password:");
            var password = Console.ReadLine();
            string _ip_h = "";
            string _lg_h = "";

            Net http = new Net(); //Создаем объект
           string html = http.GetHtml("https://vk.com", "");

            var _regexIph = new Regex(_patternIph);
            Match _matchesIph = _regexIph.Match(html);

            var _regexLgh = new Regex(_patternLgh);
            Match _matchesLgh = _regexLgh.Match(html);

            string _stringIph = _matchesIph.ToString();
            string _stringLgh = _matchesLgh.ToString();

            string[] _wordsIph = _stringIph.Split('"');
            string[] _wordsLgh = _stringLgh.Split('"');

            if (_wordsIph.Length > 0 & _wordsLgh.Length > 0)
            {
                _ip_h = _wordsIph[5];
                _lg_h = _wordsLgh[5];
            }

            else Console.WriteLine("ERROR ip_h or lg_h");


            //if (_matchesIph != null & _matchesLgh != null)
            //{
            //    Console.WriteLine(_matchesIph);
            //    Console.WriteLine(_matchesLgh);
            //}
            //else Console.WriteLine("FFFFUUUUUCCCCCCKKKKK!!!!");

            Console.WriteLine("{0}::{1}", _ip_h, _lg_h);
            //string post = "&email=" + login + "&pass=" + password + "&q=1&act=login&q=1&al_frame=1&expire=&captcha_sid=&captcha_key=&from_host=vk.com&from_protocol=http&ip_h="+_ip_h+"&quick_expire=1";
            string post = "&ip_h="+_ip_h+"&lg_h="+_lg_h+"&role=al_frame&email="+login+"&pass="+password+"&expire=&captcha_sid=&captcha_key=&_origin=http://vk.com&q=1";


            //Console.WriteLine(html);

             html = http.GetHtml("https://login.vk.com/?act=login", post);
            
            //Regex rex4 = new Regex("parent\.onLoginDone\(\'(.*?)\'\)", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            //matc4 = rex4.Match(html);
            //this.userid = matc4.Groups[1].ToString().Replace("/id", "");
            //html = http.GetHtml("https://vk.com/id" + this.userid, "");
            //int status = Testlogin(html);
            Console.WriteLine(html);
            Console.ReadKey();




        }
    }
}
