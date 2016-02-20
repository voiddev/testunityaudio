using System.Text;
using UnityEngine;

namespace Scripts.Utils {
    public class Logger {

        string name;
        bool enabled { get; set; }

        static string parseMessage(string loggerName, params object [] message) {
            StringBuilder builder = new StringBuilder();
            builder
            .Append("[")
            .Append(loggerName)
            .Append("] ");
            for (int i = 0; i < message.Length; i++) {
                builder.Append(message[i].ToString());
                builder.Append("  ");
            }
            return builder.ToString();
        }


        public Logger(string name) : this(name, true) {
            this.name = name;
        }

        public Logger(string name, bool enabled) {
            this.name = name;
            this.enabled = enabled;
        }

        public void Info (params object [] message) {
            if (!enabled) {
                return;
            }
            Debug.Log(parseMessage(name, message));
        }
    }
}