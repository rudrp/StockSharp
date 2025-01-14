namespace StockSharp.Messages
{
	using System;
	using System.ComponentModel;
	using System.Runtime.Serialization;

	using Ecng.Common;
	using Ecng.Serialization;

	using StockSharp.Localization;

	/// <summary>
	/// Сообщение, содержащее данные об инструменте.
	/// </summary>
	[System.Runtime.Serialization.DataContract]
	[Serializable]
	public class SecurityMessage : Message
	{
		/// <summary>
		/// Идентификатор инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.Str361Key)]
		[DescriptionLoc(LocalizedStrings.SecurityIdKey, true)]
		[MainCategory]
		[ReadOnly(true)]
		public SecurityId SecurityId { get; set; }

		/// <summary>
		/// Название инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.NameKey)]
		[DescriptionLoc(LocalizedStrings.Str362Key)]
		[MainCategory]
		public string Name { get; set; }

		/// <summary>
		/// Короткое название инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.Str363Key)]
		[DescriptionLoc(LocalizedStrings.Str364Key)]
		[MainCategory]
		public string ShortName { get; set; }

		/// <summary>
		/// Минимальный шаг объема.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.VolumeStepKey)]
		[DescriptionLoc(LocalizedStrings.Str366Key)]
		[MainCategory]
		[Nullable]
		public decimal? VolumeStep { get; set; }

		/// <summary>
		/// Коэфициент объема между лотом и активом.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.Str330Key)]
		[DescriptionLoc(LocalizedStrings.LotVolumeKey)]
		[MainCategory]
		[Nullable]
		public decimal? Multiplier { get; set; }

		/// <summary>
		/// Количество знаков в цене после запятой.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.DecimalsKey)]
		[DescriptionLoc(LocalizedStrings.Str548Key)]
		[MainCategory]
		[Nullable]
		public int? Decimals { get; set; }
		
		/// <summary>
		/// Минимальный шаг цены.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.PriceStepKey)]
		[DescriptionLoc(LocalizedStrings.MinPriceStepKey)]
		[MainCategory]
		[Nullable]
		public decimal? PriceStep { get; set; }

		/// <summary>
		/// Тип инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.TypeKey)]
		[DescriptionLoc(LocalizedStrings.Str360Key)]
		[MainCategory]
		[Nullable]
		public SecurityTypes? SecurityType { get; set; }

		/// <summary>
		/// Дата экспирация инструмента (для деривативов - экспирация, для облигаций - погашение).
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.ExpiryDateKey)]
		[DescriptionLoc(LocalizedStrings.Str371Key)]
		[MainCategory]
		[Nullable]
		public DateTimeOffset? ExpiryDate { get; set; }

		/// <summary>
		/// Дата выплат по инструмента (для деривативов и облигаций).
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.SettlementDateKey)]
		[DescriptionLoc(LocalizedStrings.Str373Key)]
		[MainCategory]
		[Nullable]
		public DateTimeOffset? SettlementDate { get; set; }

		/// <summary>
		/// Код базового актива, на основе которого построен данный инструмент.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.UnderlyingAssetKey)]
		[DescriptionLoc(LocalizedStrings.UnderlyingAssetCodeKey)]
		public string UnderlyingSecurityCode { get; set; }

		/// <summary>
		/// Страйк цена опциона.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.StrikeKey)]
		[DescriptionLoc(LocalizedStrings.OptionStrikePriceKey)]
		[Nullable]
		public decimal? Strike { get; set; }

		/// <summary>
		/// Тип опциона.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.OptionsContractKey)]
		[DescriptionLoc(LocalizedStrings.OptionContractTypeKey)]
		[Nullable]
		public OptionTypes? OptionType { get; set; }

		/// <summary>
		/// Тип бинарного опциона.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.BinaryOptionKey)]
		[DescriptionLoc(LocalizedStrings.TypeBinaryOptionKey)]
		public string BinaryOptionType { get; set; }

		/// <summary>
		/// Валюта торгового инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.CurrencyKey)]
		[DescriptionLoc(LocalizedStrings.Str382Key)]
		[MainCategory]
		[Nullable]
		public CurrencyTypes? Currency { get; set; }

		/// <summary>
		/// Идентификатор первоначального сообщения <see cref="SecurityLookupMessage.TransactionId"/>,
		/// для которого данное сообщение является ответом.
		/// </summary>
		[DataMember]
		public long OriginalTransactionId { get; set; }

		/// <summary>
		/// Класс инструмента.
		/// </summary>
		[DataMember]
		[DisplayNameLoc(LocalizedStrings.ClassKey)]
		[DescriptionLoc(LocalizedStrings.SecurityClassKey)]
		[MainCategory]
		public string Class { get; set; }

		/// <summary>
		/// Создать <see cref="SecurityMessage"/>.
		/// </summary>
		public SecurityMessage()
			: base(MessageTypes.Security)
		{
		}

		/// <summary>
		/// Инициализировать <see cref="SecurityMessage"/>.
		/// </summary>
		/// <param name="type">Тип сообщения.</param>
		protected SecurityMessage(MessageTypes type)
			: base(type)
		{
		}

		/// <summary>
		/// Создать копию объекта <see cref="SecurityMessage"/>.
		/// </summary>
		/// <returns>Копия.</returns>
		public override Message Clone()
		{
			var clone = new SecurityMessage();
			CopyTo(clone);
			return clone;
		}

		/// <summary>
		/// Скопировать данные сообщения в <paramref name="destination"/>.
		/// </summary>
		/// <param name="destination">Объект, в который копируется информация.</param>
		public void CopyTo(SecurityMessage destination)
		{
			if (destination == null)
				throw new ArgumentNullException("destination");

			destination.SecurityId = SecurityId;
			destination.Name = Name;
			destination.ShortName = ShortName;
			destination.Currency = Currency;
			destination.ExpiryDate = ExpiryDate;
			destination.OriginalTransactionId = OriginalTransactionId;
			destination.OptionType = OptionType;
			destination.PriceStep = PriceStep;
			destination.Decimals = Decimals;
			destination.SecurityType = SecurityType;
			destination.SettlementDate = SettlementDate;
			destination.Strike = Strike;
			destination.UnderlyingSecurityCode = UnderlyingSecurityCode;
			destination.VolumeStep = VolumeStep;
			destination.Multiplier = Multiplier;
			destination.Class = Class;
			destination.BinaryOptionType = BinaryOptionType;
			destination.LocalTime = LocalTime;
		}

		/// <summary>
		/// Получить строковое представление.
		/// </summary>
		/// <returns>Строковое представление.</returns>
		public override string ToString()
		{
			return base.ToString() + ",Sec={0}".Put(SecurityId);
		}
	}
}