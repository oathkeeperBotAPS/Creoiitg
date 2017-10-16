using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        

        private Dictionary<string, string> replies = new Dictionary<string, string>() {
          { "hey", "Heey, buddy. How was ur day."},
          { "hi", "Hii, How was day."},
          { "whatsup", "Nothing Important, How was your day."},
          { "hello", "Hello there, How was your day"},
          { "yello", "Yo, buddy. Whats up."},
          { "hiiii", "HIIIIIIIIIIIIIIIII, sup"}  
        };
        //populate();
       
        
        
        
        
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LuisAppId"], ConfigurationManager.AppSettings["LuisAPIKey"])))
        {
            
        }
       

        //  override public async  Task StartAsync(IDialogContext context) {
        //      await context.PostAsync($"Hi, aapki kya sahayta karu.");
        //      context.Wait(NoneIntent);
        //  }
        

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"NoneIntent : {result.Intents.Count}"); //
            context.Wait(MessageReceived);
        }
        
        

        

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "MyIntent" with the name of your newly created intent in the following handler
        [LuisIntent("convo")]
        public async Task convoIntent(IDialogContext context, LuisResult result)
        {
            
        
            //public void populate() {

                //return;
           // }
            
            
            string reply = "";
            //reply += $"{result.Entities[0].Type}";
            //reply += $"{replies["hello"]}";
            
            //  List<string> detectedEntities = new List<string>();
             
            foreach( EntityRecommendation en in result.Entities ) {
                if (en.Type == "hayhello") {
                    string val = "";
                    if ( replies.TryGetValue($"{en.Entity}", out val )) {
                        reply += replies[$"{en.Entity}"];
                    }
                    else {
                        reply += "Hi, I am Creo.";
                    }
                      
                }
            }
            
            //  int pos = 0;
            //  if ( detectedEntities.Contains("hayhello") ) {
            //      for ( int i = 0, j = detectedEntities.Count; i < j; j++ ) {
            //          reply += $"{i}.";
            //          Console.WriteLine("jakjf");
            //          if ( detectedEntities[i] == "hayhello" ) {
            //              pos = i;
            //          }
            //      }
                
            //      if ( replies.ContainsKey(result.Entities[pos].Entity) ) {
            //          reply = replies[result.Entities[pos].Entity];
            //      }
            //  }
            //  else {
            //      reply += "nohayheloo";
            //  }
            
            //Console.WriteLine("jakjf");
            //reply += $"{result.Intents[0].Intent}";
            
            await context.PostAsync($"{reply}"); //
            context.Wait(MessageReceived);
        }
        
        
        
    }
}