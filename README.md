# HW30
�������� �������
��������, Event-�, ��������� ����������� ����������

����:
����������� ������:

������ � ���������
��������� ���������� ����� ����������� ������

��������/��������� ���������� ���������� ��������� �������:
�������� ����� ImageDownloader. � ���� ������ ������ ���� ����� Download, ������� ��������� �������� �� ���������. ��� �������� �������� ����� ������������ �������� ����� ���: https://dotnetfiddle.net/5oT1Hi
// ������ ����� ������
string remoteUri = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
// ��� ������� ���� �� �����
string fileName = "bigimage.jpg";
// ������ �������� � ������� ����������
var myWebClient = new WebClient();
Console.WriteLine("����� \"{0}\" �� \"{1}\" .......\n\n", fileName, remoteUri);
myWebClient.DownloadFile(remoteUri, fileName);
Console.WriteLine("������� ������ \"{0}\" �� \"{1}\"", fileName, remoteUri);
�������� ��������� ����� ������ � �������� ���������� ������� ��������, ��������, https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg
� ����� ������ ��������� �������� � ������� "������� ����� ������� ��� ������" � �������� ������� ����� �������.
�������� �������: � ������ ImageDownloader � ������ ���������� �������� � � ����� ���������� �������� ����������� ������� (event) ImageStarted � ImageCompleted ��������������.
� �������� ���� ��������� ����������� �� ��� �������, � � ������������ �� ������������ �������� ��������������� ����������� � �������: "���������� ����� ��������" � "���������� ����� �����������".
�������� ����� ImageDownloader.Download �����������. ���� �� ��������� �������� � �������������� WebClient.DownloadFile, �� ����������� ������ WebClient.DownloadFileTaskAsync - �� ���������� Task.
� ����� ������ ��������� �������� ������ ����� "������� ������� A ��� ������ ��� ����� ������ ������� ��� �������� ������� ����������" � �������� ������� ����� �������. ���� ������ ������� "A" - �������� �� ���������. � ��������� ������ �������� ��������� �������� �������� (True - ���������, False - ���). ��������� ��������� ����� ����� ����� Task.IsCompleted.
����������! ���� �������� �������� �������� ���������� � �������� ������� �������.
������������� ��������� ����� �������, ����� ��� ��������� ����� 10 �������� ������������, ������������ ������������ ��� ������ �� ������� ������ "A". �� ������� ������ ������ �������� �� ����� ������ ����������� �������� � �� ��������� - ��������� ��� ���, ���������� ������ ��� ����� ��������.