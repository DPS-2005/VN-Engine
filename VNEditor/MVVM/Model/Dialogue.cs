using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEditor.MVVM.Model
{
    public class Dialogue
    {
        public string DialogueText{get; set;}
        public Scene? NextScene { get; set; }

        public Dialogue(string dialogueText, Scene? nextScene)
        {
            DialogueText = dialogueText;
            NextScene = nextScene;
        }
    }
}
