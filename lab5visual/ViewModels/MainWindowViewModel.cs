using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ReactiveUI;
using System.IO;
using System.Reactive;

namespace lab5visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text;
        string regExp;
        string res;
        public string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }

        public string Expression
        {
            get => regExp;
            set => regExp = value;
        }

        public string Res
        {
            get => res;
            set => this.RaiseAndSetIfChanged(ref res, value);
        }

        public static string FindRegexInText(string Text, string CurrentRegex)
        {
            if (CurrentRegex == String.Empty || CurrentRegex == null)
            {
                return "Exception";
            }

            string Result = "";

            Regex regex = new Regex(CurrentRegex);

            MatchCollection match = regex.Matches(Text);

            foreach (Match x in match)
            {
                Result += (x.Value + "\n");
            }

            return Result;
        }

        public string FindRegex() => FindRegexInText(text, Expression);
    }
}
