﻿using Rin.Core.Abstractions;
using Rin.Core.General;
using Rin.Editor;
using Serilog;
using Serilog.Exceptions;
using System.Drawing;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    // .Enrich.WithProperty("Environment", builder.Configuration.GetSection("environment").Value)
    .WriteTo.Console()
    .CreateLogger();

var project = Project.CreateProject("Example 1", "../Examples/Project1");
project.Save();
var editor = new EditorManager(project);

editor.Watch();

Log.Information("Bar");

// var compiler = new ShaderCompiler();
// compiler.Test();

var app = new Application();

// Test API
var scene = SceneManager.CreateScene("Main Scene");
SceneManager.SetActiveScene(scene);

var boxObj = new GameObject();
boxObj.AddComponent<MeshFilter>();


// VertexArray? vertexArray = null;
Mesh? box = null;
Material? material = null;


app.MainWindow.Load += () => {
    Log.Information("Application Loading");
    RenderCommand.Initialize();

    box = Mesh.CreateBox();
    box.SetupMesh();

    // vertexArray = VertexArray.Create();
    // float[] vertices = {
    //     -0.5f, -0.5f, 0.0f, 0.8f, 0.2f, 0.8f, 1.0f,
    //     0.5f, -0.5f, 0.0f, 0.2f, 0.3f, 0.8f, 1.0f,
    //     0.0f,  0.5f, 0.0f, 0.8f, 0.8f, 0.2f, 1.0f
    // };
    //
    // var vertexBuffer = VertexBuffer.Create(vertices);
    // var bufferLayout = new BufferLayout(
    //     new[] {
    //         new BufferElement(ShaderDataType.Float3, "a_Position"), new BufferElement(ShaderDataType.Float4, "a_Color")
    //     }
    // );
    //
    // vertexBuffer.Layout = bufferLayout;
    // vertexArray.AddVertexBuffer(vertexBuffer);
    //
    // int[] indices = { 0, 1, 2 };
    // var indexBuffer = IndexBuffer.Create(indices);
    // vertexArray.SetIndexBuffer(indexBuffer);

    Shader.Create(
        "Basic/Shader1",
        "../Examples/Project1/Assets/Shaders/Shader.vert",
        "../Examples/Project1/Assets/Shaders/Shader.frag"
    );

    material = new(Shader.Find("Basic/Shader1")!);
    material.SetColor("u_Color", Color.Bisque);

    Log.Information("Application Loaded");
};

app.MainWindow.Render += deltaTime => {
    RenderCommand.SetClearColor(Color.Gray);
    RenderCommand.Clear();
    // This can be called from SilkWindow
    // RenderCommand.SetViewport(Point.Empty, new Size(128, 128));

    if (Input.GetKey(Key.A)) {
        Log.Information("Key A pressed");
    }

    if (Input.GetKeyDown(Key.W)) {
        Log.Information("Key W Down");
    }

    if (Input.GetKeyUp(Key.W)) {
        Log.Information("Key W Up");
    }

    material?.Render();
    if (box != null) {
        RenderCommand.Draw(box);
    }
};

// This needs to be set after the RenderCommand.Clear() is called
var guiRenderer = new GuiRenderer(app, project);


// TODO: Example of creating a few objects
// {
// var box = new GameObject();
// box.AddComponent<Transform>();
//     var meshFilter = box.AddComponent<MeshFilter>();
//     meshFilter.Mesh = Mesh.CreateBox();
//
//     // This should render object in the scene
//     box.AddComponent<MeshRenderer>();
//     
//     // Create scene
//     // Load scene
// }


app.Run();

return 0;
