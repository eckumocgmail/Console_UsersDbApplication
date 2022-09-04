using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
///     Контейнер объектов типа IServiceProvider.
/// Метод GetService( ... ) вернёт первый результат
/// отличный от null, полученный в ходе последовательного
/// исп. метода GetService( ... ) поставщиков исп.
/// порядок их регистрации.
/// </summary>
public class CoalesceProvider: IServiceProvider
{
    private ConcurrentBag<IServiceProvider>_providers = 
        new ConcurrentBag<IServiceProvider>();


    public bool IsStatefull { get; } = true;
    
    /// <summary>
    /// Регистрация поставщика слжубных типов
    /// </summary>
    public int AddServiceProvider<TServiceProvider>()
        where TServiceProvider : IServiceProvider
    {
        this.Info($"Регистрация поставщика служб: {typeof(TServiceProvider).GetType().Name} c " +
            $"приоритетом {this._providers.Count}");
        try
        {
            var instance = (IServiceProvider)New(typeof(TServiceProvider));
            this._providers.Add(instance);            
        }
        catch (Exception ex)
        {
            throw new Exception($"Не удалось создать экземпляр " +
                $"поставщика служебных типов {typeof(TServiceProvider).GetType().Name}",ex);
        }
        return this._providers.Count;
    }

    private object New(Type type)
    {
        try
        {
            object result = null;
            if (type == null)
                throw new ArgumentNullException($"type");
            ConstructorInfo constructor = GetDefaultConstructor(type);
            if (constructor == null)
            {
                throw new Exception($"Тип {type.Name} не обьявляет контруктор по-умолчанию");
            }
            else
            {
                try
                {

                    result = constructor.Invoke(new object[0]);
                    return result;
                }
                catch (Exception ex)
                {
                    this.Error(ex);
                    throw new Exception("Ошибка при создании объекта " + type.Name, ex);
                }


            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Не удалось создать отражение объекта типа {type.Name}", ex);
        }
    }



    /// <summary>
    /// Поиск конструктора по-умолчанию
    /// </summary>
    /// <param name="type">Ссылка на тип</param>
    /// <returns>конструктор</returns>
    public static ConstructorInfo GetDefaultConstructor(Type type)
    {
        return (from c in new List<ConstructorInfo>(type.GetConstructors()) where c.GetParameters().Length == 0 select c).FirstOrDefault();
    }


    private void Error(Exception ex)
    {
        throw new NotImplementedException();
    }

    private void Info(object p)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Регистрация поставщика слжубных типов
    /// </summary>
    public int AddServiceProvider(IServiceProvider instance)     
    {
        if(instance == null)
            throw new ArgumentNullException(nameof(instance));
        this.Info($"Регистрация поставщика служб: {instance.GetType().Name} c " +
            $"приоритетом {this._providers.Count}");
        return this._providers.Count;
    }

    /// <summary>
    /// Получение ссылки исп. систему внедрения зависимостей
    /// </summary>
    public object GetService(Type serviceType)
    {
        object result = null;
        try
        {
            
            foreach (IServiceProvider serviceProvider in _providers)
            {
                try
                {
                    if ((result = serviceProvider.GetService(serviceType)) != null)
                        return result;
                }
                catch (Exception ex)
                {
                    this.Warn(ex);
                    continue;
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"При получении зависимости {serviceType.GetType().Name}", ex);
        }
    }

    private void Warn(Exception ex)
    {
        throw new NotImplementedException();
    }
}

