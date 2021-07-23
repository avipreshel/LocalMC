# Messaging channel for IPC (Inter Process Communication)
This project simplifies the usage of shared-memory communication channel. Just create either an Input or Output channel, give them a name and start sending text or binary messages between two processes.

# Why shared memory
If your project needs to communicate between processes which will reside on the same machine/OS, then shared memory (aka "named pipes") is the fastest way to go about.

# Why not just use shared memory directly, without LocalMC?
Because then you would need to bother yourself with the synchronizations between the producer/consumer, and also you'll need to take care of the cleanups. It's just too messy.

# Why not just use WCF with named pipes as transport?
WCF is a general communication framework, so it's got additional abstraction layers which hinder the performance compared to LocalMC. Also, WCF requires lots of setup and multiple lines of code to get it up and running. LocalMC is super simple (sample app included in the solution).

# The Source and this project's deviation from the source
The code is based on Joe Albahari's "Pushing C# to the limits" (https://youtu.be/mLX1sYVf-Xg). The code found in https://gist.github.com/Manuel-S/a28eb3fea190fdd7b0e4ac2b90151588 by Manuel Schweigert.
The original project by Joe was used for RPC-IPC (Remote Procedure Call between processes). This project (LocalMC = Local Messaging Channel) is merely extracted from the lower Input/Output channels. The idea is that RPC is too fancy, and in most cases, you just need to send message from process A to process B, ASAP.

# How to use
- Download the project and compile the solution with VS2019
- Run the sample app LocalMC_Example.exe
 
# Tech stack used
- C# w/ .Net 5
- The project will work only on Windows. Perhaps future .Net release shall allow this project to be fully portable to Linux

# Design
- As simple as possible. Two classes: One for the Product ("OutPipe") and one for the consumer ("InPipe")

# Help needed
- I would appriciate if anyone is interested to create a benchmark Vs. WCF or any other messaging system.
