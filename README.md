http://ccnuyan.github.io/iccnu-oauth2

# ICCNU Oauth2 Authentication Flow Instruction

***

## Before You Begin
�������⻧Ӧ�õĵ�����֤��վ OAuth2 ����֤�������֤���̡�����ĵ����⻧Ӧ�õĿ����߲ο���

��ΪӦ�õĿ����ߣ�����Ҫ���Ӧ�õĲ�ͬ���ͣ�����Ҫ���õ���֤���̽���ѡ��B/SӦ����Ҫ�ο�Authorization Code Grant Flow��C/SӦ����Ҫ�ο�Resource Owner Password Credentials Grant Flow��

��֤���̽������⻧Ӧ����Ҫ�����Լ���Ӧ���Ƿ������߲������û�Ⱥ�壬�����������û���������˻��ĵ�¼���̡�
  
***

####1.�⻧ΪB/SӦ��
��Ҫ�ο� Authorization Code Grant Flow���û�����֤վ���¼����ת������Ӧ�ú�Ӧ��ʾ�û��������˻���ֱ�Ӵ������û���������¼״̬��
####2.�⻧ΪC/SӦ��
��Ҫ�ο� Resource Owner Password Credentials Grant Flow���û���¼������Ӧ�ú�Ӧ��ʾ�û��������˻���ֱ�Ӵ������û���������¼״̬��

##1 �⻧ΪB/SӦ��: ʹ�� Authorization Code Grant Flow ��֤

####ʹ���Ⱦ�����
1. ����û���Ҫ����ICCNU��ע��Ϊ�û���

2. ����Ҫ�����Ӧ�������ΪICCNU��֤������⻧��

�����ΪICCNU��֤������⻧ʱ���⻧Ӧ����ҪΪ��֤վ�����Ա�ṩ����Ϣ������

   **�ص���ַ** "redirectURI" : "http://localhost:8080/account/login"

   **�⻧Ӧ��Id** "id" : "code_test"

   **�⻧Ӧ������** "secret" : *****

   **��ҳ��ַ** "homeURI" : "http://localhost:8080/"

   **�⻧Ӧ����** "name" : "����Ӧ����1"

   **�⻧Ӧ������** "description" : "�����ǲ���Ӧ��1��������Ϣ"

   **��֤����** "authType" : "code"

���У��ص���ַ���⻧Ӧ��Id���⻧Ӧ������ΪAuthorization Code Grant Flow��֤��������Ҫ�õ��ı����ֶ�; ��ҳ��ַ���⻧Ӧ����, �⻧Ӧ������Ϊ��ʾ���û����ֶΣ����Ǳ���ģ���֤������Authorization Code Grant Flow�й̶�Ϊ"Code"��   

####��֤����
1 �û�����⻧Ӧ����ҳ�ϵġ�ʹ��ICCNU�˻���¼��ʱ��Я���⻧ע������������ص���ַ���⻧Ӧ��Id����֤���͵ȣ���ת����֤ҳ�档

2 �û���¼����֤ҳ��������Ӧ����Ϣ���û�������Ϣ���û���Ȩ�⻧Ӧ�ã��û���Ȩ�⻧����ʾ�û������⻧Ӧ��ͨ����õ���AccessToken������֤��վ�ķ��񣬰������̷�����Դ����ȣ���õ��û�����Դ��֮��Я��code��ת�����Ӧ�õĻص�ҳ�档

3 �⻧Ӧ�ûص�ҳ���ڴ����߼��У�Я��code���⻧����Ϣ�������ص���ַ���⻧Ӧ��Id���⻧Ӧ�����룬��֤���ͣ���������ʵķ�������Ϊȫ�򣩵ȣ�������֤վ���token���񣬵õ��û���AccessToken��

4 �⻧Ӧ��ͨ��AccessToken������֤վ���Me���񣬵õ��û�����֤��Ϣ����֤���̽�����

��ʱ�⻧Ӧ���Ѿ�֪��������֤վ��ICCNU��¼���û��Ļ�����Ϣ�����Լ����⻧Ӧ���Լ���ҵ�񣨰��Ѵ��ڵı����û����߸��ݵ�¼��Ϣ�����û��ȵȣ���

##2 �⻧ΪC/SӦ��: ʹ�� Resource Owner Password Credentials Grant Flow ��֤

####ʹ���Ⱦ�����
1. ����û���Ҫ����ICCNU��ע��Ϊ�û���

2. ����Ҫ�����Ӧ�������ΪICCNU��֤������⻧��

�����ΪICCNU��֤������⻧ʱ���⻧Ӧ����ҪΪ��֤վ�����Ա�ṩ����Ϣ������

   **�⻧Ӧ��Id** "id" : "code_test"

   **�⻧Ӧ������** "secret" : *****

   **��ҳ��ַ "homeURI"** : "http://localhost:8080/"

   **�⻧Ӧ����** "name" : "����Ӧ����1"

   **�⻧Ӧ������** "description" : "�����ǲ���Ӧ��1��������Ϣ"

   **��֤����** "authType" : "resource_owner"

���У��⻧Ӧ��Id���⻧Ӧ������ΪResource Owner Password Credentials Grant Flow��֤��������Ҫ�õ��ı����ֶ�; ��ҳ��ַ���⻧Ӧ����, �⻧Ӧ������Ϊ��ʾ���û����ֶΣ����Ǳ���ģ���֤������Resource Owner Password Credentials Grant Flow�й̶�Ϊ"resource_owner"��   

C/SӦ�ò�������������н�����֤���̣����Բ���Ҫ�ṩ�ص���ַ�ֶΡ�

####��֤����

1 �û�����ͻ��˵ġ�ʹ��ICCNU�˻���¼��ʱ����������֤վ����ע����û��������롣

2 �ͻ����ں�̨Я���û�������û��������뼰�⻧����Ϣ�������ص���ַ���⻧Ӧ��Id���⻧Ӧ�����룬��֤���ͣ���������ʵķ�������Ϊȫ�򣩵ȣ�������֤վ���token���񣬵õ��û���AccessToken��

3 �⻧Ӧ��ͨ��AccessToken������֤վ���Me���񣬵õ��û�����֤��Ϣ����֤���̽�����

��ʱ�⻧Ӧ���Ѿ�֪����¼�û��Ļ�����Ϣ�����Լ����⻧Ӧ���Լ���ҵ�񣨰��Ѵ��ڵı����û����߸��ݵ�¼��Ϣ�����û��ȵȣ���

PS: B/Sվ�������ʹ�� Resource Owner Password Credentials Grant, ���ǲ�������������

##�ο�
Authorization Code Grant
https://tools.ietf.org/html/rfc6749#section-4.1

Resource Owner Password Credentials Grant
https://tools.ietf.org/html/rfc6749#section-4.3

��֤���̵ľ��弼��ϸ�ڣ����η�ʽ�ȼ�������

##���е�����
**dot net BS Authorization Code Grant��**dot net B/S ���� (��֤���̼���2)

**dot net CS Resource Owner Password Credentials Grant��**dot net C/S ����

**node.js BS Authorization Code Grant��**node.js B/S ����

��1��

**��֤վ��:** http://www.iccnu.net/

**��֤ҳ��:** http://www.iccnu.net/oauth2/authorize

(�⻧Ӧ��ҳ�����ڵ�� ʹ��ICCNU�˻���¼ ʱ����Ҫ�ض������ĵ�ַ)

**AccessToken API End Point:** http://www.iccnu.net/api/oauth2/token

(�⻧Ӧ���ڵõ�Code����Ҫʹ��Code����վ�ϻ�ȡ����֤�û���AccessToken�����Ǹ���Code��ȡAccessToken�ķ����ַ)

**Me API End Point:** http://www.iccnu.net/api/oauth2/me

(�⻧Ӧ���ڵõ�AccessToken�󣬸���AccessToken����û���֤��Ϣ�ķ����ַ)

��2 ��������������΢��OAuth2������֤��ҵ������ �� dot net B/S�������⻧Ӧ������ICCNUOAuth2������֤��ҵ�����̵� ����

step 1 ������/�⻧Ӧ�õ�¼���ض�������֤վ��

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu01.jpg)

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant01.jpg)

step 2 �û�������΢��/ICCNU�ϵ�½����Ȩ������/�⻧Ӧ�û�ȡ��֤��Ϣ��Ȼ���ض�����������/�⻧Ӧ��վ��

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu02.jpg)

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant02.jpg)

step 3 ������/�⻧վ���ȡ���û�����֤��Ϣ����֤������������/�⻧վ��������Լ���ҵ��

��ͼ�п��Կ��������������������Լ����û������������ÿ����������������˻����û�ѡ������е��˻�����ʹ��΢����֤�����¼���û�ԭ����û������������ע�������ѡ�������˲�������ֱ�Ӹ���΢����֤���񷵻ص���֤��Ϣ�����µ��˻���

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu03.jpg)

����dot net B/S�����У��⻧Ӧ��ֱ�Ӹ��ݷ��ص���֤��Ϣ�������µ��û�
![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant03.jpg)