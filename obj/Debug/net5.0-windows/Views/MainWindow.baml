   M S B A M L   `   `   `  ����L  HWPF_MVVM_Template, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WPF_MVVM_Template.ModelsWPF_MVVM_Template.Models  5   	   H DTelegram.Bot, Version=16.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:Telegram.Bot.Types;assembly=Telegram.BotTelegram.Bot.Types 5   	   "    WPF_MVVM_Template.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9models&clr-namespace:WPF_MVVM_Template.Models     5   	   Htypes6clr-namespace:Telegram.Bot.Types;assembly=Telegram.Bot     5   	   $	��370��5	   !   $	��701��6.     � DataContext  5   	   �� *MainWindowViewModel+   Locator �� Source# [   � Title 5	   	   �� *Title+.��5
      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��Файл��6   .@�5      m� $��
Выйти��6     CloseWindowCommand m� Command# [ 6*   5      m� 5      $��Сервис��6   6)   m� 5      $��Помощь��6   6)   5      �� 5   
   $��Bottom=�6   .@�5      �� $��Right=�6   .��5      �� 5      �� 5      $��Right=�6   .��5      �� $��Right=�6     StopBotCommand#��[ 60   $��Отключить��6�   ��6Z   �� *CurrentConfig+6�   5      �� 5      $��Статус: Готов!��6   5      � 5   
   $	��Top=�6   $��3q�6$    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5       �� 5!      $
��Auto �6#   �� 5"      �� 5#      $
��Auto �6#   .+�5%      �� $��0��6   $��0��6(   $��Токен бота :��65   $
��Bold"�6I    �� TextAlignment$ Right=�6[   $
��10,5q�6q   �� 5&       � ToolTip$ Введите токен��6   $��1��6.   $��0��6>   $
��10,5q�6�   ��6K   �� *Token+ �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 5'      $��0��6   $��1��6(   $��Ключ Weather API :��65   $
��Bold"�6O   $ Right=�6a   $
��10,5q�6w   �� 5(      $$ Введите Weather API Key��6   $��1��68   $��1��6H   $
��10,5q�6�   ��6U   �� *WeatherKeyAPI+$ 	LostFocus=�6�   �� 5)      $��2��6   $��1��6'   $��Запомнить��64   $
��10,5q�6H   ]� 5*      $��2��6   $��1��6(   .+�5+      �� 	 �� 
IsReadOnly$
	 True��6   $��0q�6,   �� 5,      $��
Войти��6     StartBotCommand#��[ 6*   ��6U   �� *CurrentConfig+5-      5.      � 5/   
   $��3q�6    50      �� 51      $
��Auto �6#   $	��110��60   �� 52      $	��86* �6#   �� 53      $
��109* �6#   .+�55      �� $��0��6   $#��Имя - Cообщений{-}��6'   .��56      �� 
 �� SelectedIndex$
 0��6b   ��6   �� *	Clients+ �� SelectedItem 6:   �� *SelectedClient+��57      �� 58       �� 
TargetType" ��6    .�59      ��  �� Property � �� �� Value$ Stretch=�6K   5:      ��5<      �� 5=       �� DataType$ models:Client��6'   .R�5>      ]� .+�5?   "   �� $��Right=�6,   ��6C   �� *Messages.Count+ �� StringFormat$ ({0})���� 5@   "   ��6,   �� *
Username+5A      5B      5D      5E      �� 5F      $��1��6   $%��Список сообщений��6'   .��5G      �� ��6   �� *SelectedClient.Messages+ 6J   �� *SelectedMessage+��5H      �� 5I      " ��6    .�5J      ��  � ��$ Stretch=�6K   5K      ��5M      �� 5N      $ types:Message��6'   .R�5O      ]� .+�5P   "   �� $��Right=�6,   ��6C   �� *Date+�� 5Q   "   ��6,   �� *Chat.FirstName+�� 5R   "   $�� ��6,   5S      5T      5V      5W      �� 5X      $��2��6   $��Сообщения��6'   .��5Y      �  5Z      �� 5[      $��4* �6(   �� 5\      $��2* �6(   �� 5]      $
��0.8* �6(   .+�5_      �� $��0��6    $- 'Полученное сообщение��5`       $
��Left=�5a       $��WrapWithOverflow=�5b       ��5_   -   �� *SelectedMessage.Text+$ PropertyChanged=�5b       �� 5d      $ Введите ответ��5e      $��1��5f       J� Opacity$
 0.53Q�5g       �� TextWrapping$ WrapWithOverflow=�5h      ��5d      �� *Answer+$ PropertyChanged=�5h      �� 5j      $��2��6   $+��%Отправить сообщение��6*   $	��150��6H     SendMessageCommand#��[ 5k      ��5l      �� *MainWindowViewModel+# [  5m      5n      �� 5o      $��1��6   $
��Left=�6+   $��3��6F   $ 0Q�6P   �� 5p      $��2��6   $
��Left=�6+   $��3��6F   $ 0Q�6P   5q      5r      5s      