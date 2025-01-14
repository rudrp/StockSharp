namespace StockSharp.Messages
{
	using System;
	using System.Runtime.Serialization;

	using Ecng.Common;

	using StockSharp.Localization;

	/// <summary>
	/// Сообщение, содержащее фильтр для снятия заявок.
	/// </summary>
	[DataContract]
	[Serializable]
	public class OrderGroupCancelMessage : OrderMessage
	{
		///// <summary>
		///// Тип инструмента. Если значение <see langword="null"/>, то отмена идет по всем типам инструментов.
		///// </summary>
		//[DataMember]
		//[DisplayName("Тип")]
		//[Description("Тип инструмента.")]
		//[MainCategory]
		//public SecurityTypes? SecurityType { get; set; }

		/// <summary>
		/// Идентификатор транзакции отмены.
		/// </summary>
		[DataMember]
		public long TransactionId { get; set; }

		/// <summary>
		/// <see langword="true"/>, если нужно отменить только стоп-заявки, <see langword="false"/> - если только обычный и <see langword="null"/> - если оба типа.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.Str226Key)]
		[DescriptionLoc(LocalizedStrings.Str227Key)]
		[MainCategory]
		public bool? IsStop { get; set; }

		/// <summary>
		/// Направление заявки. Если значение равно <see langword="null"/>, то направление не попадает в фильтр снятия заявок.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.Str128Key)]
		[DescriptionLoc(LocalizedStrings.Str228Key)]
		[MainCategory]
		public Sides? Side { get; set; }

		/// <summary>
		/// Создать <see cref="OrderGroupCancelMessage"/>.
		/// </summary>
		public OrderGroupCancelMessage()
			: base(MessageTypes.OrderGroupCancel)
		{
		}

		/// <summary>
		/// Получить строковое представление.
		/// </summary>
		/// <returns>Строковое представление.</returns>
		public override string ToString()
		{
			return base.ToString() + ",IsStop={0},Side={1},SecType={2}".Put(IsStop, Side, SecurityType);
		}

		/// <summary>
		/// Создать копию объекта <see cref="OrderGroupCancelMessage"/>.
		/// </summary>
		/// <returns>Копия.</returns>
		public override Message Clone()
		{
			var clone = new OrderGroupCancelMessage
			{
				LocalTime = LocalTime,
				SecurityId = SecurityId,
				IsStop = IsStop,
				OrderType = OrderType,
				PortfolioName = PortfolioName,
				//SecurityType = SecurityType,
				Side = Side,
				TransactionId = TransactionId,
				ClientCode = ClientCode,
				BrokerCode = BrokerCode,
			};

			CopyTo(clone);

			return clone;
		}
	}
}