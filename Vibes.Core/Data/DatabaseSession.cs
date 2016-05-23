using NHibernate;
using NHibernate.Engine;
using NHibernate.Stat;
using NHibernate.Type;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Linq;
using NHibernate.Linq;

namespace Vibes.Core.Data
{
	public class DatabaseSession : IDatabaseSession
	{
		ISession _session;

		public DatabaseSession(ISession session)
		{
			_session = session;
		}

		public IQueryable<T> Query<T>()
		{
			return _session.Query<T>();
		}

		public object Save(object obj)
		{
			return _session.Save(obj);
		}

		public void Delete(object obj)
		{
			_session.Delete(obj);
		}

		public T Get<T>(object id)
		{
			return _session.Get<T>(id);
		}

		public object Get(Type clazz, object id)
		{
			return _session.Get(clazz, id);
		}

		public EntityMode ActiveEntityMode
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public CacheMode CacheMode
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IDbConnection Connection
		{
			get
			{
				return _session.Connection;
			}
		}

		public bool DefaultReadOnly
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public FlushMode FlushMode
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsConnected
		{
			get
			{
				return _session.IsConnected;
			}
		}

		public bool IsOpen
		{
			get
			{
				return _session.IsOpen;
			}
		}

		public ISessionFactory SessionFactory
		{
			get
			{
				return _session.SessionFactory;
			}
		}

		public ISessionStatistics Statistics
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ITransaction Transaction
		{
			get
			{
				return _session.Transaction;
			}
		}

		public ITransaction BeginTransaction()
		{
			return _session.BeginTransaction();
		}

		public ITransaction BeginTransaction(IsolationLevel isolationLevel)
		{
			return _session.BeginTransaction(isolationLevel);
		}

		public void CancelQuery()
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public IDbConnection Close()
		{
			return _session.Close();
		}

		public bool Contains(object obj)
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria(string entityName)
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria(Type persistentClass)
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria(string entityName, string alias)
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria(Type persistentClass, string alias)
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public ICriteria CreateCriteria<T>(string alias) where T : class
		{
			throw new NotImplementedException();
		}

		public IQuery CreateFilter(object collection, string queryString)
		{
			throw new NotImplementedException();
		}

		public IMultiCriteria CreateMultiCriteria()
		{
			throw new NotImplementedException();
		}

		public IMultiQuery CreateMultiQuery()
		{
			throw new NotImplementedException();
		}

		public IQuery CreateQuery(string queryString)
		{
			throw new NotImplementedException();
		}

		public ISQLQuery CreateSQLQuery(string queryString)
		{
			throw new NotImplementedException();
		}

		public int Delete(string query)
		{
			throw new NotImplementedException();
		}

		public void Delete(string entityName, object obj)
		{
			throw new NotImplementedException();
		}

		public int Delete(string query, object[] values, IType[] types)
		{
			throw new NotImplementedException();
		}

		public int Delete(string query, object value, IType type)
		{
			throw new NotImplementedException();
		}

		public void DisableFilter(string filterName)
		{
			throw new NotImplementedException();
		}

		public IDbConnection Disconnect()
		{
			return _session.Disconnect();
		}

		public void Dispose()
		{
			_session.Dispose();
		}

		public IFilter EnableFilter(string filterName)
		{
			throw new NotImplementedException();
		}

		public void Evict(object obj)
		{
			throw new NotImplementedException();
		}

		public void Flush()
		{
			throw new NotImplementedException();
		}

		public object Get(string entityName, object id)
		{
			throw new NotImplementedException();
		}

		public object Get(Type clazz, object id, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public T Get<T>(object id, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public LockMode GetCurrentLockMode(object obj)
		{
			throw new NotImplementedException();
		}

		public IFilter GetEnabledFilter(string filterName)
		{
			throw new NotImplementedException();
		}

		public string GetEntityName(object obj)
		{
			throw new NotImplementedException();
		}

		public object GetIdentifier(object obj)
		{
			throw new NotImplementedException();
		}

		public IQuery GetNamedQuery(string queryName)
		{
			throw new NotImplementedException();
		}

		public ISession GetSession(EntityMode entityMode)
		{
			throw new NotImplementedException();
		}

		public ISessionImplementor GetSessionImplementation()
		{
			throw new NotImplementedException();
		}

		public bool IsDirty()
		{
			throw new NotImplementedException();
		}

		public bool IsReadOnly(object entityOrProxy)
		{
			throw new NotImplementedException();
		}

		public object Load(string entityName, object id)
		{
			throw new NotImplementedException();
		}

		public void Load(object obj, object id)
		{
			throw new NotImplementedException();
		}

		public object Load(Type theType, object id)
		{
			throw new NotImplementedException();
		}

		public object Load(string entityName, object id, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public object Load(Type theType, object id, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public T Load<T>(object id)
		{
			throw new NotImplementedException();
		}

		public T Load<T>(object id, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public void Lock(object obj, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public void Lock(string entityName, object obj, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public object Merge(object obj)
		{
			throw new NotImplementedException();
		}

		public object Merge(string entityName, object obj)
		{
			throw new NotImplementedException();
		}

		public T Merge<T>(T entity) where T : class
		{
			throw new NotImplementedException();
		}

		public T Merge<T>(string entityName, T entity) where T : class
		{
			throw new NotImplementedException();
		}

		public void Persist(object obj)
		{
			throw new NotImplementedException();
		}

		public void Persist(string entityName, object obj)
		{
			throw new NotImplementedException();
		}

		public IQueryOver<T, T> QueryOver<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public IQueryOver<T, T> QueryOver<T>(string entityName) where T : class
		{
			throw new NotImplementedException();
		}

		public IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class
		{
			throw new NotImplementedException();
		}

		public IQueryOver<T, T> QueryOver<T>(string entityName, Expression<Func<T>> alias) where T : class
		{
			throw new NotImplementedException();
		}

		public void Reconnect()
		{
			throw new NotImplementedException();
		}

		public void Reconnect(IDbConnection connection)
		{
			throw new NotImplementedException();
		}

		public void Refresh(object obj)
		{
			throw new NotImplementedException();
		}

		public void Refresh(object obj, LockMode lockMode)
		{
			throw new NotImplementedException();
		}

		public void Replicate(object obj, ReplicationMode replicationMode)
		{
			throw new NotImplementedException();
		}

		public void Replicate(string entityName, object obj, ReplicationMode replicationMode)
		{
			throw new NotImplementedException();
		}

		public object Save(string entityName, object obj)
		{
			return _session.Save(entityName, obj);
		}

		public void Save(object obj, object id)
		{
			_session.Save(obj, id);
		}

		public void Save(string entityName, object obj, object id)
		{
			_session.Save(entityName, obj, id);
		}

		public void SaveOrUpdate(object obj)
		{
			_session.SaveOrUpdate(obj);
		}

		public void SaveOrUpdate(string entityName, object obj)
		{
			_session.SaveOrUpdate(entityName, obj);
		}

		public void SaveOrUpdate(string entityName, object obj, object id)
		{
			_session.SaveOrUpdate(entityName, obj, id);
		}

		public ISession SetBatchSize(int batchSize)
		{
			return _session.SetBatchSize(batchSize);
		}

		public void SetReadOnly(object entityOrProxy, bool readOnly)
		{
			_session.SetReadOnly(entityOrProxy, readOnly);
		}

		public void Update(object obj)
		{
			_session.Update(obj);
		}

		public void Update(string entityName, object obj)
		{
			_session.Update(entityName, obj);
		}

		public void Update(object obj, object id)
		{
			_session.Update(obj, id);
		}

		public void Update(string entityName, object obj, object id)
		{
			_session.Update(entityName, obj, id);
		}
	}
}
