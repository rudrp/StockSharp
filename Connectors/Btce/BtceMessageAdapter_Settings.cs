namespace StockSharp.Btce
{
	using System.ComponentModel;
	using System.Linq;
	using System.Security;

	using Ecng.Common;
	using Ecng.Serialization;

	using StockSharp.Localization;
	using StockSharp.Messages;

	using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

	[DisplayName("BTC-e")]
	[CategoryLoc(LocalizedStrings.BitcoinsKey)]
	[DescriptionLoc(LocalizedStrings.Str1770Key, "BTC-e")]
	[CategoryOrderLoc(LocalizedStrings.Str174Key, 0)]
	[CategoryOrderLoc(LocalizedStrings.Str186Key, 1)]
	[CategoryOrderLoc(LocalizedStrings.LoggingKey, 2)]
	partial class BtceMessageAdapter
	{
		/// <summary>
		/// Ключ.
		/// </summary>
		[CategoryLoc(LocalizedStrings.Str174Key)]
		[DisplayNameLoc(LocalizedStrings.Str3304Key)]
		[DescriptionLoc(LocalizedStrings.Str3304Key, true)]
		[PropertyOrder(1)]
		public SecureString Key { get; set; }

		/// <summary>
		/// Секрет.
		/// </summary>
		[CategoryLoc(LocalizedStrings.Str174Key)]
		[DisplayNameLoc(LocalizedStrings.Str3306Key)]
		[DescriptionLoc(LocalizedStrings.Str3307Key)]
		[PropertyOrder(2)]
		public SecureString Secret { get; set; }

		/// <summary>
		/// Проверить введенные параметры на валидность.
		/// </summary>
		[Browsable(false)]
		public override bool IsValid
		{
			get
			{
				if (SupportedMessages.Contains(MessageTypes.OrderRegister))
					return !Key.IsEmpty() && !Secret.IsEmpty();
				else
					return true;
			}
		}

		/// <summary>
		/// Сохранить настройки.
		/// </summary>
		/// <param name="storage">Хранилище настроек.</param>
		public override void Save(SettingsStorage storage)
		{
			base.Save(storage);

			storage.SetValue("Key", Key);
			storage.SetValue("Secret", Secret);
		}

		/// <summary>
		/// Загрузить настройки.
		/// </summary>
		/// <param name="storage">Хранилище настроек.</param>
		public override void Load(SettingsStorage storage)
		{
			base.Load(storage);

			Key = storage.GetValue<SecureString>("Key");
			Secret = storage.GetValue<SecureString>("Secret");
		}

		/// <summary>
		/// Получить строковое представление контейнера.
		/// </summary>
		/// <returns>Строковое представление.</returns>
		public override string ToString()
		{
			return LocalizedStrings.Str3304 + " = " + Key;
		}
	}
}