using UnityEngine;
using JahnStarGames.Langpipe;
using JahnStarGames.Langpipe.Providers.GoogleApis;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using NaughtyAttributes;
using Aeterponis;
using Unity.VisualScripting;

public class AITest : MonoBehaviour
{
    public bool newChat = true;
    public string systemPromptTemplate = "Senin ismin {npc_name}. Benim en iyi arkadaþým olduðun bir rol yapýyorsun. Rolden çýkma.Cevap verirken 60 karakteri aþma!. Benim adým {user_name}.";
    public List<FormatPromptValue> systemPromptFormat = new() { new("npc_name", "Jessica"), new("user_name", "User") };
    [Space]
    public string userPrefix = "John";
    public string aiPrefix = "Jessica";
    public string userPrompt = "What's my name?";
    [Space]
    public List<Message> messages = new();
    [TextArea(3, 10)]
    public string result;
    private Pipeline pipeline;

    IChatModel model;

    int count = 0;

    private async Task Init()
    {
        model = new ChatGeminiAIModel("apikey", new ChatGeminiAIRequest { Model = "gemini-1.5-flash-latest", Temperature = 0.5f }, verbose: new(true));

        var memory = new SummaryMemory((model, (userPrefix, aiPrefix), 200), "history");

        pipeline = new(model, memory, verbose: new(debugHighVerbose: true));

        if (newChat)
        {
            pipeline.AddSystemMessage(systemPromptTemplate, systemPromptFormat)
                .AddUserMessage("Merhaba Jessica")
                .SaveMemory();

            OSManager.instance.InstantiateUserText("Merhaba Jessica");
        }
        else pipeline.LoadMemory().AddUserMessage(userPrompt);

        result = await pipeline.RunAsync();
        OSManager.instance.InstantiateAIText(result.ToLower(),true);

        messages = pipeline.GetMessages();
    }

    private async void Start()
    {
        await Init();
    }


    public async void AutoConversation(string prompt)
    {
        if (count > 2)
        {
            OSManager.instance.steps++;
            return;
        }

        userPrompt = await model.CallAsync("[Don't use prefix, be yourself. Don't be obsessive, be natural, Answer in Turkish and give short answers!] " + prompt);
        await Task.Delay(1000);
        await ConversationLoop();
    }

    public async Task ConversationLoop()
    {
        pipeline.AddUserMessage(userPrompt)
        .SaveMemory();
        result = await pipeline.RunAsync();
        OSManager.instance.InstantiateAIText(result.ToLower());
        OSManager.instance.steps++;
        count++;
        // debug
        messages = pipeline.GetMessages();
    }
}
