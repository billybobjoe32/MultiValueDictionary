using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryApp
{
    public class MultiValueDictionary
    {
        private const string EMPTY_SET = "(empty set)";
        private const string ERROR_KEY_NOT_FOUND = ") ERROR, key does not exist.";
        private const string ERROR_MEMBER_NOT_FOUND = ") ERROR, member does not exist.";
        private const string ERROR_MEMBER_ALREADY_EXISTS_FOR_KEY = ") ERROR, member already exists for key";
        private const string INVALID_NUMBER_OF_PARAMETERS_ONE = " command only allows for one parameter";
        private const string INVALID_NUMBER_OF_PARAMETERS_TWO = " command only allows for two parameters";
        private const string INVALID_COMMAND = ") Command not recognized, please try again.";
        private const string ADDED = ") Added";
        private const string REMOVED = ") Removed";
        private const string CLEARED = ") Cleared";
        private const string THANS_FOR_USING_THE_APP = ") Thanks for using the MultiValueDictionary app!";
        public Dictionary<string, List<string>> Dictionary { get; set; }

        public MultiValueDictionary()
        {
            Dictionary = new Dictionary<string, List<string>>();
        }

        public string ProcessRequest(string? request)
        {
            if(String.IsNullOrEmpty(request))
            {
                return INVALID_COMMAND;
            }
            string[] splitCommand = request.Split(' ');
            string command = splitCommand[0].ToLower();
            string output;
            switch (command)
            {
                case "keys":
                    output = Keys();
                    output = output.Trim();
                    return output;
                case "members":
                    if (splitCommand.Length == 2)
                    {
                        output = Members(splitCommand[1]);
                        output = output.Trim();
                        return output;
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_ONE}";
                    }
                case "add":
                    if(splitCommand.Length == 3)
                    {
                        return Add(splitCommand[1], splitCommand[2]);
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_TWO}";
                    }
                case "remove":
                    if (splitCommand.Length == 3)
                    {
                        return Remove(splitCommand[1], splitCommand[2]);
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_TWO}";
                    }
                case "removeall":
                    if (splitCommand.Length == 2)
                    {
                        return RemoveAll(splitCommand[1]);
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_ONE}";
                    }
                case "clear":
                    return Clear();
                case "keyexists":
                    if (splitCommand.Length == 2)
                    {
                        return KeyExists(splitCommand[1]);
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_ONE}";
                    }
                case "memberexists":
                    if (splitCommand.Length == 3)
                    {
                        return MemberExists(splitCommand[1], splitCommand[2]);
                    }
                    else
                    {
                        return $") {command.ToUpper()}{INVALID_NUMBER_OF_PARAMETERS_TWO}";
                    }
                case "allmembers":
                    output = AllMembers();
                    output = output.Trim();
                    return output;
                case "items":
                    output = Items();
                    output = output.Trim();
                    return output;
                case "quit":
                    return THANS_FOR_USING_THE_APP;
                default:
                    return INVALID_COMMAND;
            }
        }

        private string Items()
        {
            if (Dictionary.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (string key in Dictionary.Keys)
                {
                    foreach (string value in Dictionary[key])
                    {
                        sb.AppendLine($"{count++}) {key}: {value}");
                    }
                }
                return sb.ToString();
            }
            else
            {
                return EMPTY_SET;
            }
        }

        private string AllMembers()
        {
            if(Dictionary.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (string key in Dictionary.Keys)
                {
                    foreach(string value in Dictionary[key])
                    {
                        sb.AppendLine($"{count++}) {value}");
                    }
                }
                return sb.ToString();
            }
            else
            {
                return EMPTY_SET;
            }
        }

        private string MemberExists(string key, string value)
        {
            return ") " + (Dictionary.ContainsKey(key) && Dictionary[key].Contains(value)).ToString().ToLower();
        }

        private string KeyExists(string key)
        {
            return ") " + Dictionary.ContainsKey(key).ToString().ToLower();
        }

        private string Clear()
        {
            Dictionary.Clear();
            return CLEARED;
        }

        private string RemoveAll(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary.Remove(key);
                return REMOVED;
            }
            else
            {
                return ERROR_KEY_NOT_FOUND;
            }
        }

        private string Remove(string key, string value)
        {
            if (Dictionary.ContainsKey(key))
            {
                if (Dictionary[key].Contains(value))
                {
                    Dictionary[key].Remove(value);
                    if(Dictionary[key].Count == 0)
                    {
                        Dictionary.Remove(key);
                    }
                    return REMOVED;
                }
                else
                {
                    return ERROR_MEMBER_NOT_FOUND;
                }
            }
            else
            {
                return ERROR_KEY_NOT_FOUND;
            }
        }

        private string Members(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (string value in Dictionary[key])
                {
                    sb.AppendLine($"{count++}) {value}");
                }
                return sb.ToString();
            }
            else
            {
                return ERROR_KEY_NOT_FOUND;
            }
        }

        public string Keys()
        {
            if(Dictionary.Count == 0)
            {
                return EMPTY_SET;
            }
            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach(string key in Dictionary.Keys)
            {
                sb.AppendLine($"{count++}) {key}");
            }
            return sb.ToString();
        }

        public string Add(string key, string value)
        {
            if (Dictionary.ContainsKey(key))
            {
                if (Dictionary[key].Contains(value))
                {
                    return ERROR_MEMBER_ALREADY_EXISTS_FOR_KEY;
                }
                else
                {
                    Dictionary[key].Add(value);
                    return ADDED;
                }
            }
            else
            {
                Dictionary.Add(key, new List<string> { value });
                return ADDED;
            }
        }
    }
}
