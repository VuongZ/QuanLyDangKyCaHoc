using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace finalproject.Infrastructure.Messaging;
public class RabbiMqPublisher
{
    private readonly string _hostname="localhost";
    public async Task PublishDangKySucess(int idlophoc,int idsinhvien)
    {
        var factory=new ConnectionFactory{HostName = _hostname};
        await using var connection=await factory.CreateConnectionAsync();
        await using var channel=await connection.CreateChannelAsync();
        channel.QueueDeclareAsync(
            queue: "DangKy-Sucess",
            durable:false,
            exclusive:false,
            autoDelete:false
        );
        var message=JsonSerializer.Serialize(new
        {
            IdLophoc=idlophoc,
            IdSinhVien=idsinhvien,
            ThoiGian=DateTime.Now
        });
        var body=Encoding.UTF8.GetBytes(message);
        await channel.BasicPublishAsync
        (
            exchange: " ",
            routingKey: "Dang Ky Thanh Cong",
            body:body
        );
        
    }
}