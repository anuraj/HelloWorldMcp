# HelloWorld Mcp

This is a sample implementation of File based MCP server. It is exposing only one tool which echo's the message to client.

It is a .NET 10 feature, to use this MCP server, create `mcp.json` file under `.vscode` with the following snippet.

```json
{
	"servers": {
		"file-based-mcp": {
			"type": "stdio",
			"command": "dotnet",
			"args": [
				"run",
				"Program.cs"
			]
		}
	},
	"inputs": []
}
```

Now we can use GitHub Copilot and ask the question like this `Can you echo "Hello World"?` - which will prompt the Tool execution and respond like this.