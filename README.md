# aspnetcore-lambda-layers-example
A Sample application to demonstrate working with AWS Lambda Layers with ASP.NET Core. To Get Started with AWS Lambda Layers, learn why to use Lambda Layers and how it helps in decoupling application and keeping the deployment package simple.

https://referbruv.com/blog/posts/creating-aws-lambda-layers-in-aspnet-core-getting-started

Although Lambda Layers can be used to push stale package references into externalized layers and let Lambda use these from the layers, we might also want to have our Custom Class libraries which might contain business logic to work in the same way, so that they could be reused in other lambda functions as well. For this, we make use of Nuget packages to pack and store our libraries. Learn how to implement this and deploy our libraries in Layers.

https://referbruv.com/blog/posts/deploying-custom-class-libraries-in-aws-lambda-layers
