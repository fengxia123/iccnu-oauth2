http://ccnuyan.github.io/iccnu-oauth2

# ICCNU Oauth2 Authentication Flow Instruction

***

## Before You Begin
这里是租户应用的调用认证主站 OAuth2 的认证服务的认证流程。这个文档给租户应用的开发者参考。

作为应用的开发者，你需要针对应用的不同类型，对需要采用的认证流程进行选择。B/S应用需要参考Authorization Code Grant Flow，C/S应用需要参考Resource Owner Password Credentials Grant Flow。

认证流程结束后，租户应用需要根据自己的应用是否已上线并存在用户群体，继续创建新用户或绑定已有账户的登录流程。
  
***

####1.租户为B/S应用
需要参考 Authorization Code Grant Flow，用户在认证站点登录并跳转至您的应用后，应提示用户绑定已有账户或直接创建新用户，后进入登录状态。
####2.租户为C/S应用
需要参考 Resource Owner Password Credentials Grant Flow，用户登录至您的应用后，应提示用户绑定已有账户或直接创建新用户，后进入登录状态。

##1 租户为B/S应用: 使用 Authorization Code Grant Flow 认证

####使用先决条件
1. 你的用户需要现在ICCNU上注册为用户。

2. 你需要将你的应用申请成为ICCNU认证服务的租户。

申请成为ICCNU认证服务的租户时，租户应用需要为认证站点管理员提供的信息包括：

   **回调地址** "redirectURI" : "http://localhost:8080/account/login"

   **租户应用Id** "id" : "code_test"

   **租户应用密码** "secret" : *****

   **主页地址** "homeURI" : "http://localhost:8080/"

   **租户应用名** "name" : "测试应用名1"

   **租户应用描述** "description" : "这里是测试应用1的描述信息"

   **认证类型** "authType" : "code"

其中，回调地址、租户应用Id及租户应用密码为Authorization Code Grant Flow认证流程中需要用到的必须字段; 主页地址，租户应用名, 租户应用描述为显示给用户的字段，不是必须的；认证类型在Authorization Code Grant Flow中固定为"Code"。   

####认证流程
1 用户点击租户应用网页上的“使用ICCNU账户登录”时，携带租户注册参数（包括回调地址，租户应用Id，认证类型等）跳转到认证页面。

2.1 用户登录后，认证页面呈现你的应用信息及用户个人信息，用户授权租户应用（用户授权租户、表示用户允许租户应用通过获得到的AccessToken访问认证主站的服务，包括网盘服务，资源服务等，获得到用户的资源）之后，携带code跳转回你的应用的回调页面。

2.2 租户应用回调页面在处理逻辑中，携带code及租户的信息（包括回调地址，租户应用Id，租户应用密码，认证类型）及申请访问的服务域（暂为全域）等，调用认证站点的token服务，得到用户的AccessToken。

3 租户应用通过AccessToken调用认证站点的Me服务，得到用户的认证信息，认证流程结束。

此时租户应用已经知道调用认证站点ICCNU登录的用户的基本信息，可以继续租户应用自己的业务（绑定已存在的本地用户或者根据登录信息创建用户等等）。

##2 租户为C/S应用: 使用 Resource Owner Password Credentials Grant Flow 认证

####使用先决条件
1. 你的用户需要现在ICCNU上注册为用户。

2. 你需要将你的应用申请成为ICCNU认证服务的租户。

申请成为ICCNU认证服务的租户时，租户应用需要为认证站点管理员提供的信息包括：

   **租户应用Id** "id" : "code_test"

   **租户应用密码** "secret" : *****

   **主页地址 "homeURI"** : "http://localhost:8080/"

   **租户应用名** "name" : "测试应用名1"

   **租户应用描述** "description" : "这里是测试应用1的描述信息"

   **认证类型** "authType" : "resource_owner"

其中，租户应用Id及租户应用密码为Resource Owner Password Credentials Grant Flow认证流程中需要用到的必须字段; 主页地址，租户应用名, 租户应用描述为显示给用户的字段，不是必须的；认证类型在Resource Owner Password Credentials Grant Flow中固定为"resource_owner"。   

C/S应用并不是在浏览器中进行认证流程，所以不需要提供回调地址字段。

####认证流程

1 用户点击客户端的“使用ICCNU账户登录”时，输入在认证站点上注册的用户名与密码。

2 客户端在后台携带用户输入的用户名与密码及租户的信息（包括回调地址，租户应用Id，租户应用密码，认证类型）及申请访问的服务域（暂为全域）等，调用认证站点的token服务，得到用户的AccessToken。

3 租户应用通过AccessToken调用认证站点的Me服务，得到用户的认证信息，认证流程结束。

此时租户应用已经知道登录用户的基本信息，可以继续租户应用自己的业务（绑定已存在的本地用户或者根据登录信息创建用户等等）。

PS: B/S站点亦可以使用 Resource Owner Password Credentials Grant, 但是不建议这样做。

##参考
Authorization Code Grant
https://tools.ietf.org/html/rfc6749#section-4.1

Resource Owner Password Credentials Grant
https://tools.ietf.org/html/rfc6749#section-4.3

##包中的内容
**dot net BS Authorization Code Grant：**dot net B/S 例子 (认证流程见附2)

**dot net CS Resource Owner Password Credentials Grant：**dot net C/S 例子

**node.js BS Authorization Code Grant：**node.js B/S 例子

##附1 各服务调用地址（传参方式等继续更新）：

**认证站点:** http://www.iccnu.net/

**认证页面:** http://www.iccnu.net/oauth2/authorize

(租户应用页面上在点击 使用ICCNU账户登录 时，需要重定向至的地址)

**AccessToken API End Point:** http://www.iccnu.net/api/oauth2/token

(租户应用在得到Code后，需要使用Code到主站上获取已认证用户的AccessToken，这是跟据Code获取AccessToken的服务地址)

**Me API End Point:** http://www.iccnu.net/api/oauth2/me

(租户应用在得到AccessToken后，根据AccessToken获得用户认证信息的服务地址)

##附2 认证流程样例对照

土巴兔利用新浪微博OAuth2服务认证的业务流程 与 dot net B/S例子中租户应用利用ICCNUOAuth2服务认证的业务流程 对照

step 1 土巴兔/租户应用登录，重定向至认证站点

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu01.jpg)

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant01.jpg)

step 2 用户在新浪微博/ICCNU上登陆，授权土巴兔/租户应用获取认证信息，然后重定向至土巴兔/租户应用站点

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu02.jpg)

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant02.jpg)

step 3 土巴兔/租户站点获取到用户的认证信息，认证结束，土巴兔/租户站点继续其自己的业务

从图中可以看见，由于土巴兔有其自己的用户，所以土巴兔可以让已有土巴兔账户的用户选择绑定已有的账户；若使用微博认证服务登录的用户原来并没有在土巴兔上注册过，则选择跳过此步，可以直接根据微博认证服务返回的认证信息创建新的账户。

![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tu03.jpg)

而在dot net B/S例子中，租户应用直接根据返回的认证信息创建了新的用户
![](https://raw.githubusercontent.com/ccnuyan/iccnu-oauth2/master/imgs/tenant03.jpg)

##附3 联系方式

QQ83000710 严中华

##附4 API & http context

### 1 redirect full uri example

	http://www.iccnu.net/oauth2/authorize?client_id=code_test&redirect_uri=http:%2F%2Flocalhost:8080%2FAccount%2FLogin&state=-0Fs7e5Pj4TGr0xGK_sqSQ&response_type=code

### 1 exchage code for token
请求：

POST http://www.iccnu.net/api/oauth2/token HTTP/1.1

Authorization: Basic Y29kZV90ZXN0OmNvZGVfdGVzdA==

请求Body

    code=Zsd7aihG4qVD0771&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2Faccount%2Flogin&grant_type=authorization_code

响应
HTTP/1.1 200 OK

响应Body

    {
	"access_token":"[token]",
	"token_type":"Bearer"
	}


### 2 get user info by token
请求：
GET http://www.iccnu.net/api/oauth2/me HTTP/1.1

Authorization: Bearer [token]

响应
HTTP/1.1 200 OK

响应Body

    {
	"_id":"55a5b5e95d0054010020d313",
	"rootDirectory":"55a5b5e95d0054010020d314",
	"displayName":"starcyan",
	"provider":"starc",
	"username":"yan_starc",
	"__v":0,
	"created":"2015-07-15T01:22:49.394Z",
	"roles":["user"],
	"email":"yan@starc.com.cn",
	"lastName":"yan",
	"firstName":"starc"
	}