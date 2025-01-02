# Microservices Desc

Microservices architecture (often shortened to microservices) refers to an architectural style for developing applications. Microservices allow a large application to be separated into smaller independent parts, with each part having its own realm of responsibility.

## Communication in a Microservice Architecture

Client and services can communicate through many different types of communication, each one targeting a different scenario and goals. Initially, those types of communications can be classified in two axes.

### The First Axis: Synchronous vs Asynchronous Protocols

- **Synchronous Protocol:** HTTP is a synchronous protocol. The client sends a request and waits for a response from the service. That's independent of the client code execution that could be synchronous (thread is blocked) or asynchronous (thread isn't blocked, and the response will reach a callback eventually). The important point here is that the protocol (HTTP/HTTPS) is synchronous and the client code can only continue its task when it receives the HTTP server response.
  
- **Asynchronous Protocol:** Other protocols like AMQP (a protocol supported by many operating systems and cloud environments) use asynchronous messages. The client code or message sender usually doesn't wait for a response. It just sends the message as when sending a message to a RabbitMQ queue or any other message broker.

### The Second Axis: Single Receiver vs Multiple Receivers

- **Single Receiver:** Each request must be processed by exactly one receiver or service. An example of this communication is the Command pattern.

- **Multiple Receivers:** Each request can be processed by zero to multiple receivers. This type of communication must be asynchronous. An example is the publish/subscribe mechanism used in patterns like Event-driven architecture. This is based on an event-bus interface or message broker when propagating data updates between multiple microservices through events; it's usually implemented through a service bus or similar artifact like Azure Service Bus by using topics and subscriptions.

## Communication Styles in Microservices


A microservice-based application will often use a combination of these communication styles. The most common type is single-receiver communication with a synchronous protocol like HTTP/HTTPS when invoking a regular Web API HTTP service. Microservices also typically use messaging protocols for asynchronous communication between microservices.

![image](https://github.com/user-attachments/assets/07ac65b7-8e23-4533-bf33-d0836ad2e3e9)


## Async Communication
### Message Broker 
The message broker does this by translating messages between formal messaging protocols. This allows interdependent services to “talk” with one another directly, even if they were written in different languages or implemented on different platforms
![image](https://github.com/user-attachments/assets/5e668e71-b6eb-4561-bf5a-5c2e53487e72)


## RabbitMQ
RabbitMQ is an open-source message broker that acts as an intermediary for microservices to exchange data. It uses the Advanced Message Queuing Protocol (AMQP) to ensure reliable and efficient communication. RabbitMQ allows you to decouple services, making them more scalable and resilient.
![image](https://github.com/user-attachments/assets/404977d7-0731-4676-a66c-25569c529fc0)
![image](https://github.com/user-attachments/assets/c9d7b60a-ea95-4442-940a-2cf46a3aa952)


Management Docker
<pre>docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management</pre>



## Exchanges
<ul>
  <li>
    Direct  -  default one and match the routing key (create exchange, create queue, bind ques, publish message with routing)
  </li>
  <li>
  Fanout - Send to all queues even routing is given or not
  </li>
  <li>
Topic - Similar to Direct but support wild card for example declare queue routing "abcd.*" and while publish give abcd.erewr
  </li>  <li>
Headers - it is having Extra info routing key does not matter for it only arguments should match while binding and publishing (string.Empty)
  </li>  
</ul>


