1. 登陆

   1. POST /api/login  //登陆

      参数说明：

      | 参数     | 是否必选 | 描述   |
      | -------- | -------- | ------ |
      | username | 是       | 用户名 |
      | password | 是       | 密码   |

      请求示例： POST /api/login

      参数示例：

      {

      ​	"username": "sample",

      ​	"password": "123"

      }

      响应示例：

      {

      ​	"c": 200,

      ​	"m": "success",

      ​	"d": {

      ​		"sessionId": "sample",

      ​		"user": {

      ​			"username": "123",

      ​			"displayName": "123",

      ​			"email": "sample@sample.com",

      ​			"phoneNumber": "+86 13800000000",

      ​			"remark": "remark"

      ​		}

      ​	}

      }

   2. POST /api/logout  //登出

      参数说明：

      | 参数      | 是否必选 | 描述   |
      | --------- | -------- | ------ |
      | sessionId | 是       | 会话ID |

      请求示例：POST /api/logout

      参数示例：

      {

      ​	"sessionId": "sample"

      }

      响应示例：

      {

      ​	"c": 200,

      ​	"m": "success",

      ​	"d": "success"

      }