using UnityEngine;
using JahnStarGames.Langpipe;
using JahnStarGames.Langpipe.Providers.GoogleApis;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using NaughtyAttributes;

public class AITest : MonoBehaviour
{
    public bool newChat = true;
    public string systemPromptTemplate = "Your name is {npc_name}. You are my best friend. And I am {user_name}.";
    public List<FormatPromptValue> systemPromptFormat = new() { new("npc_name", "Jessica"), new("user_name", "John") };
    [Space]
    public string userPrefix = "John";
    public string aiPrefix = "Jessica";
    public string userPrompt = "What's my name?";
    public string userPrompt2 = "What's my name?";
    [Space]
    public List<Message> messages = new();
    [TextArea(3, 10)]
    public string result;
    private Pipeline pipeline;

    IChatModel model;

    private async Task Init()
    {
        model = new ChatGeminiAIModel("AIzaSyAXgtGu_qviVlBQcdc11arAutlP4eOLJV8", new ChatGeminiAIRequest { Model = "gemini-1.0-pro", Temperature = 0.5f }, verbose: new(true));

        var memory = new SummaryMemory((model, (userPrefix, aiPrefix), 200), "history");

        pipeline = new(model, memory, verbose: new(debugHighVerbose: true));

        if (newChat)
        {
            pipeline.AddSystemMessage(systemPromptTemplate, systemPromptFormat)
                .AddUserMessage(userPrompt)
                .SaveMemory();
        }
        else pipeline.LoadMemory().AddUserMessage(userPrompt);

        result = await pipeline.RunAsync();

        messages = pipeline.GetMessages();
    }

    private async void Start()
    {
        await Init();
    }


    public async void AutoConversation(string prompt)
    {
        userPrompt = await model.CallAsync("[Don't use prefix, be yourself. Don't be obsessive, be natural.] " + prompt);
        await Task.Delay(1000);
        await ConversationLoop();
    }

    public async Task ConversationLoop()
    {
        pipeline.AddUserMessage(userPrompt)
        .SaveMemory();
        result = await pipeline.RunAsync();
        // debug
        messages = pipeline.GetMessages();
    }
}
