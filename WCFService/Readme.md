## WCF概述
### WCF的概念
Windows Communication Foundation(WCF)是由微软开发的一系列支持数据通信的应用程序框架，可以翻译为Windows 通讯开发平台。整合了原有的windows通讯的 .net Remoting，WebService，Socket的机制，并融合有HTTP和FTP的相关技术。是Windows平台上开发分布式应用最佳的实践方式。

简单的归结为四大部分:
1. 网络服务的协议，即用什么网络协议开放客户端接入。
2. 业务服务的协议，即声明服务提供哪些业务。
3. 数据类型声明，即对客户端与服务器端通信的数据部分进行一致化。
4. 传输安全性相关的定义。

WCF中常用的binding方式：

- BasicHttpBinding: 用于把 WCF 服务当作 ASMX Web 服务。用于兼容旧的Web ASMX 服务。
- WSHttpBinding: 比 BasicHttpBinding 更加安全，通常用于 non-duplex 服务通讯。
- WSDualHttpBinding: 和 WSHttpBinding 相比，它支持 duplex 类型的服务。
- WSFederationHttpBinding: WS-Federation 安全通讯协议。
- NetTcpBinding: 使用 TCP 协议，用于在局域网(Intranet)内跨机器通信。有几个特点：可靠性、事务支持和安全，优化了 WCF到 WCF 的通信。限制是服务端和客户端都必须使用 WCF 来实现。
- NetNamedPipeBinding: 使用命名管道进行安全、可靠、高效的单机服务通讯方式。
- NetMsmqBinding: 使用消息队列在不同机器间进行非连接通讯。
- NetPeerTcpBinding: 使用 P2P 协议在多机器间通讯。
- MsmqIntegrationBinding: 将 WCF 消息转化为 MSMQ 消息，使用现有的消息队列系统进行跨机器通讯。如 MSMQ。


## 快速搭建WCF程序

### 创建wcf服务项目

1. 添加一个控制台程序：MyWCFService
2. 添加“新建项”-->“WCF服务”模板，取名为“MyWCFService”。
3. 项目新增内容：
 - 自动添加了接口：vs生成`MyWCFService.cs`文件时,自动生成`IMyWCFService`接口，并自动实现接口。
```     
[ServiceContract]
public interface IMyWCFService
{
	[OperationContract]
	void DoWork();
}
```
注意：

接口类上添加了 `[ServiceContract]`特性，表示这个接口类遵循WCF协定。
接口方法上自动添加 `[OperationContract]`特性，表示这个方法是服务协定的一部分。

只有添加了以上特性，才保证接口被WCF运行时获取到。我们可以依据需要更改接口中的方法。
- App.config中的变化：新增了`system.serviceModel`配置节点：
```
<system.serviceModel>
   	<behaviors>
		<serviceBehaviors>
			<behavior name="">
				<serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
				<serviceDebug includeExceptionDetailInFaults="false" />
			</behavior>
		</serviceBehaviors>
	</behaviors>
	<services>
		<service name="MyService.MyWCFService">
			<endpoint address="" binding="basicHttpBinding" contract="MyService.IMyWCFService">
				<identity>
					<dns value="localhost" />
				</identity>
			</endpoint>
			<endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
			<host>
				<baseAddresses>
					<add baseAddress="http://localhost:8733/Design_Time_Addresses/MyService/MyWCFService/" />
				</baseAddresses>
			</host>
		</service>
	</services>
</system.serviceModel>
```
现在重点观察`services`节点内容：

- address: 表示服务地址。例如http://mywcfserver/testserver。
- binding: 表示通信通道。wcf常见的通道有:basicHttpBinding wsHttpBinding, netTcpBinding, netMSMQBinding。
- contract: 表示WCF中制定的的规则。在这里调用`MyService.IMyWCFService`
- 在`<service name="MyService.MyWCFService">`节点下，如果
`address=""`为空，则服务地址以`baseAddresses`为准：
```
<baseAddresses>
    <add baseAddress="http://localhost:8733/MyService/MyWCFService/" />
</baseAddresses>
```
在Main方法中启动服务：
```
//使用ServiceHost启动
ServiceHost host = new ServiceHost(typeof(MyWCFService));
host.Open();
Console.WriteLine("WCF服务已启动！！！！！！！");
Console.ReadLine();
```
运行服务，控制台输出：
```
WCF服务已启动！！！！！！！
```

注意，如果提示以下错误，请以管理员身份运行
```
System.ServiceModel.AddressAccessDeniedException:“HTTP 无法注册 URL http://+:8733/MyService/MyWCFService/。进程不具有此命名空间的访问权限(有关详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=70353)。”
```
### 创建wcf客户端项目

1. 创建控制台项目，MyClient
2. 添加“引用”-->“添加服务引用”，在地址中输入服务地址
```
http://localhost:8733/MyService/MyWCFService/
```
3. 点击“转到”，找到服务后，命名空间重新命名为“MyWCFService”。

注意：

**添加服务引用时，服务必须启动**。

在main方法中调用服务方法：
```
MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();
string myTask = client.GetMyTask("0001");

Console.WriteLine("我今天的任务：" + myTask);
Console.Read();
```
控制台显示内容：
```
我今天的任务：今天没有工作可做
```
## 基于netTcpBinding的WC程序

### 创建wcf服务项目

参照上面的方法创建。创建完成后在app.config中更改如下信息：
```
<services>
	<service name="MyNetTcpService.MyWCFService">
		<endpoint address="net.tcp://localhost:1234/MyWCFService" binding="netTcpBinding" contract="MyNetTcpService.IMyWCFService">
			<identity>
				<dns value="localhost" />
			</identity>
		</endpoint>
		<endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
		<host>
			<baseAddresses>
				<add baseAddress="http://localhost:8733/MyNetTcpService/MyWCFService/" />
			</baseAddresses>
		</host>
	</service>
</services>
```
### 创建wcf客户端项目

参照上面的方法创建。链接地址为`“http://localhost:8733/MyNetTcpService/MyWCFService/”`

**使用场合**： 两个.NET程序搭建的一个跨机器访问情景。tcp 远比 http [也就是BasicHttpBinding] 快的多。http通常是.NET程序和非.NET程序通信，不能使用tcp的情况下，使用SOAP。

## 基于NetMSMQBinding的WCF程序

netMSMQBinding是单工位通信，离线传输数据。

### 创建事务性的专用消息队列，标签为`private$\mywcfservice`。
	创建步骤略。

### 创建wcf服务项目

参照上面的方法创建。创建完成后，IMyWCFService类中操作契约更改为单工位，方法没有返回值。
```
public interface IMyWCFService
{
	[OperationContract(IsOneWay = true)]
	void GetMyTask(string jobId);
}
```
MyWCFService类方法更改为：
```
public void GetClientInfo(string content)
{
	Console.WriteLine($"接收到消息:{content}, 时间：{DateTime.Now.ToLongTimeString()}");
}
```
在app.config中更改如下信息：
```
<bindings>
<netMsmqBinding>
	<binding name="mybinding">
	<security mode="None"></security>
	</binding>
</netMsmqBinding>
</bindings>
<services>
	<service name="MyNetMSMQService.MyWCFService">
		<endpoint address="net.msmq://localhost/private/myteachservice" binding="netMsmqBinding" 
					contract="MyNetMSMQService.IMyWCFService" bindingConfiguration="mybinding">
			<identity>
				<dns value="localhost" />
			</identity>
		</endpoint>
		<endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
		<host>
			<baseAddresses>
				<add baseAddress="http://localhost:8733/MyNetMSMQService/MyWCFService/" />
			</baseAddresses>
		</host>
	</service>
</services>
```
### 创建wcf客户端项目

参照上面的方法创建。链接地址为`“http://localhost:8733/MyNetTcpService/MyWCFService/”`
在main方法中写入以下内容：
```
MyWCFService.MyWCFServiceClient client = new MyWCFService.MyWCFServiceClient();
Console.WriteLine("ClientApp启动");
System.Threading.Thread.Sleep(3000);
client.GetClientInfo("王小二");
Console.WriteLine("ClientApp发送第1次消息！");
System.Threading.Thread.Sleep(2000);
client.GetClientInfo("李晓红");
Console.WriteLine("ClientApp发送第2次消息！");
System.Threading.Thread.Sleep(1000);
client.GetClientInfo("流泪了");
Console.WriteLine("ClientApp发送第3次消息！");

Console.WriteLine("消息发送完毕！");
Console.Read();
```
## WCF的异步调用方法

### 创建wcf服务端

	参照快速搭建WCF服务项目

### 创建wcf客户端

	参照快速搭建wcf客户端。

	客户端连接上服务之后，右键服务-->配置服务引用-->勾选“允许生成异步操作”-->选中“生成异步操作”-->确定。

