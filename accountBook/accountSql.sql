-- --------------------------------------------------------
-- ȣ��Ʈ:                          127.0.0.1
-- ���� ����:                        10.1.28-MariaDB - mariadb.org binary distribution
-- ���� OS:                        Win32
-- HeidiSQL ����:                  11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- ���̺� dawoon.dc_account ���� ��������
DROP TABLE IF EXISTS `dc_account`;
CREATE TABLE IF NOT EXISTS `dc_account` (
  `accSeq` int(11) DEFAULT NULL COMMENT '��ȣ',
  `usedDate` varchar(20) DEFAULT NULL COMMENT '�޷�',
  `accAcount` varchar(20) DEFAULT NULL COMMENT '�������',
  `itemSeq` int(11) DEFAULT NULL COMMENT 'dc_items�� ������ȣ',
  `subject` varchar(20) DEFAULT NULL,
  `money` varchar(20) DEFAULT NULL COMMENT '��',
  `content` varchar(50) DEFAULT NULL,
  `memo` varchar(20) DEFAULT NULL COMMENT '����',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '���뿩��(Y:��ȿ/N:����)',
  `regDate` datetime DEFAULT NULL COMMENT '����������',
  `issueDate` datetime DEFAULT NULL COMMENT '����������',
  `issueID` varchar(20) DEFAULT '' COMMENT '���������� ID'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='����� ����';

-- ���̺� ������ dawoon.dc_account:~15 rows (�뷫��) ��������
DELETE FROM `dc_account`;
/*!40000 ALTER TABLE `dc_account` DISABLE KEYS */;
INSERT INTO `dc_account` (`accSeq`, `usedDate`, `accAcount`, `itemSeq`, `subject`, `money`, `content`, `memo`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(34, '2022�� 1�� 27�� �����', '����', 16, '����', '5000000', '�޿�', '�޿��Դϴ�', 'Y', '2022-01-27 13:58:37', '2022-01-27 13:58:37', 'CDY'),
	(35, '2022�� 1�� 27�� �����', '����', 15, '�뵷', '30000', '«��', '���̼�', 'Y', '2022-01-27 14:01:35', '2022-01-27 14:01:35', 'CDY'),
	(36, '2022�� 1�� 27�� �����', '����', 15, '�뵷', '10000', '¥��', 'ȥ�ڼ�', 'Y', '2022-01-27 14:01:45', '2022-01-27 14:01:45', 'CDY'),
	(37, '2022�� 1�� 27�� �����', '����', 13, '�Ĵ�', '1', '1', '1', 'N', '2022-01-27 14:53:56', '2022-01-27 14:53:56', 'CDY'),
	(38, '2022�� 1�� 27�� �����', '����', 15, '�뵷', '1', '11', '111', 'N', '2022-01-27 15:17:15', '2022-01-27 15:17:15', 'CDY'),
	(39, '2022�� 1�� 27�� �����', '����', 15, '�뵷', '22', '22', '22', 'N', '2022-01-27 15:17:24', '2022-01-27 15:17:24', 'CDY'),
	(40, '2022�� 1�� 27�� �����', '����', 23, '��', '2', '��', '2', 'N', '2022-01-27 15:39:48', '2022-01-27 15:39:48', 'CDY'),
	(41, '2022�� 1�� 27�� �����', '����', 23, '��', '3', '3', '3', 'N', '2022-01-27 15:40:30', '2022-01-27 15:40:30', 'CDY'),
	(42, '2022�� 1�� 27�� �����', '����', 24, '��', '50000', '0', '1', 'Y', '2022-01-27 15:41:53', '2022-01-27 15:41:53', 'CDY'),
	(43, '2022�� 1�� 27�� �����', '����', 25, '��', '5000', '500', '', 'Y', '2022-01-27 15:42:53', '2022-01-27 15:42:53', 'CDY'),
	(44, '2022�� 1�� 27�� �����', '����', 16, '����', '20000000', '�޿�', '2�鸸��', 'Y', '2022-01-27 15:59:21', '2022-01-27 15:59:21', 'CDY'),
	(45, '2022�� 1�� 27�� �����', '����', 0, '�뵷', '500001', '���ϼ���', '�뵷 5����', 'Y', '2022-01-27 16:00:05', '2022-01-27 16:00:05', 'CDY'),
	(46, '2022�� 1�� 27�� �����', '����', 18, '����', '2000', '���� 2000��', '���ں��� 2��', 'Y', '2022-01-27 16:00:40', '2022-01-27 16:00:40', 'CDY'),
	(47, '2022�� 1�� 27�� �����', '����', 16, '����', '122222', '22', '22', 'N', '2022-01-27 16:06:33', '2022-01-27 16:06:33', 'CDY'),
	(48, '2022�� 1�� 27�� �����', '����', 0, '����', '200000001', '�޿�', '2�鸸��', 'Y', '2022-01-27 16:26:48', '2022-01-27 16:26:48', 'CDY'),
	(49, '2022�� 1�� 27�� �����', '����', 13, '�Ĵ�', '20000', '����«��', '«�͸Ա�', 'Y', '2022-01-27 16:32:00', '2022-01-27 16:32:00', 'CDY');
/*!40000 ALTER TABLE `dc_account` ENABLE KEYS */;

-- ���̺� dawoon.dc_items ���� ��������
DROP TABLE IF EXISTS `dc_items`;
CREATE TABLE IF NOT EXISTS `dc_items` (
  `itemSeq` int(11) DEFAULT NULL COMMENT '�����۹�ȣ',
  `acount` varchar(20) DEFAULT '' COMMENT '�Ա����',
  `subject` varchar(20) NOT NULL DEFAULT '' COMMENT '����,����,�󿩱�,���ʽ�',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '���뿩��(Y:��ȿ/N:����)',
  `regDate` datetime DEFAULT NULL COMMENT '����������',
  `issueDate` datetime DEFAULT NULL COMMENT '����������',
  `issueID` varchar(20) DEFAULT '' COMMENT '���������� ID',
  PRIMARY KEY (`subject`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='����� ����';

-- ���̺� ������ dawoon.dc_items:~12 rows (�뷫��) ��������
DELETE FROM `dc_items`;
/*!40000 ALTER TABLE `dc_items` DISABLE KEYS */;
INSERT INTO `dc_items` (`itemSeq`, `acount`, `subject`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(23, '����', '��', 'Y', '2022-01-27 15:39:18', '2022-01-27 15:39:18', 'CDY'),
	(18, '����', '����', 'Y', '2022-01-26 21:29:17', '2022-01-26 21:29:17', 'CDY'),
	(20, '����', '������', 'Y', '2022-01-26 21:29:31', '2022-01-26 21:29:31', 'CDY'),
	(14, '����', '����', 'Y', '2022-01-26 16:44:08', '2022-01-26 16:44:08', 'CDY'),
	(25, '����', '��', 'Y', '2022-01-27 15:42:40', '2022-01-27 15:42:40', 'CDY'),
	(22, '����', '������', 'Y', '2022-01-27 15:11:09', '2022-01-27 15:11:09', 'CDY'),
	(24, '����', '��', 'Y', '2022-01-27 15:41:41', '2022-01-27 15:41:41', 'CDY'),
	(17, '����', '���ʽ�', 'Y', '2022-01-26 19:17:22', '2022-01-26 19:17:23', 'CDY'),
	(13, '����', '�Ĵ�', 'Y', '2022-01-26 14:08:21', '2022-01-26 14:08:21', 'CDY'),
	(15, '����', '�뵷', 'Y', '2022-01-26 19:11:48', '2022-01-26 19:11:48', 'CDY'),
	(16, '����', '����', 'Y', '2022-01-26 19:16:59', '2022-01-26 19:16:59', 'CDY'),
	(21, '����', '���ɽĴ�', 'Y', '2022-01-27 12:02:12', '2022-01-27 12:02:12', 'CDY'),
	(19, '����', '�÷���', 'Y', '2022-01-26 21:29:26', '2022-01-26 21:29:26', 'CDY');
/*!40000 ALTER TABLE `dc_items` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
