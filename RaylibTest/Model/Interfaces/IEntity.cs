namespace RaylibTest.Model;

public interface IEntity<out T>
{
    public T Type();
}