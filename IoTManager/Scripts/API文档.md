1. 设备信息

   1. GET /api/device  //获取所有设备信息

      请求示例：GET /api/device

      响应示例：

      {
          "c": 200,
          "m": "success",
          "d": [
              {
                  "id": 1,
                  "hardwareDeviceID": "asdfaefae",
                  "deviceName": "asdfasdfa",
                  "city": "Nanjing",
                  "factory": "Shanghai University",
                  "workshop": "Tongji University",
                  "deviceState": "Normal",
                  "lastConnectionTime": "2019-04-16T20:45:53+08:00",
                  "imageUrl": "jojo",
                  "gatewayID": 3,
                  "mac": "szdfgs",
                  "deviceType": "General Device",
                  "createTime": "2019-04-16T20:45:53+08:00",
                  "updateTime": "2019-04-16T20:45:53+08:00",
                  "remark": "adfe",
                  "department": "Offcial"
              }

      ​	]

      }

   2. GET /api/device/{id}  //获取指定ID设备信息

      请求示例:  GET /api/device/5

      响应示例:

      {
          "c": 200,
          "m": "success",
          "d": {
              "id": 5,
              "hardwareDeviceID": "19279nu10v098",
              "deviceName": "Test Device 5",
              "city": "Kashi",
              "factory": "Shanghai University",
              "workshop": "Tongji University",
              "deviceState": "Error",
              "lastConnectionTime": "2019-04-21T00:36:55+08:00",
              "imageUrl": "https://www.bilibili.com",
              "gatewayID": 5,
              "mac": "apdojgaoieg",
              "deviceType": "General Device",
              "createTime": "2019-04-21T00:36:55+08:00",
              "updateTime": "2019-04-21T00:36:55+08:00",
              "remark": "A Test Device",
              "department": "Official 3"
          }
      }

   3. POST /api/device  //添加设备信息

      参数说明：

      | 参数             | 是否必选 | 描述                       |
      | ---------------- | -------- | -------------------------- |
      | hardwareDeviceID | 是       | 硬件设备ID                 |
      | deviceName       | 是       | 硬件设备名称               |
      | city             | 是       | 城市                       |
      | factory          | 是       | 工厂                       |
      | workshop         | 是       | 车间                       |
      | deviceState      | 是       | 设备状态                   |
      | imageUrl         | 是       | 设备照片URL                |
      | gatewayID        | 是       | 网关设备ID                 |
      | mac              | 是       | 硬件设备MAC地址            |
      | deviceType       | 是       | 硬件设备类型（是否有网关） |
      | remark           | 是       | 备注                       |
      | department       | 是       | 设备所属部门               |

      请求示例：POST /api/device

      参数示例：

      {
      	"hardwareDeviceID": "Not the previous Test Device",
      	"deviceName": "Test Device 26",
      	"city": "Nanjing",
      	"factory": "Fudan University",
      	"workshop": "Tongji University",
      	"deviceState": "Error",
      	"imageUrl": "https://www.douyu.com",
      	"gatewayID": 17,
      	"mac": "apdojgaoieg",
      	"deviceType": "General Device",
      	"remark": "A Test Device",
      	"department": "Official 2"
      }

      响应示例：

      {
          "c": 200,
          "m": "success",
          "d": {
              "id": 0,
              "hardwareDeviceID": "Not the previous Test Device",
              "deviceName": "Test Device 26",
              "city": "Nanjing",
              "factory": "Tongji University",
              "workshop": "Tongji University",
              "deviceState": "Error",
              "lastConnectionTime": "2019-04-25T23:18:28.423837+08:00",
              "imageUrl": "https://www.douyu.com",
              "gatewayID": 17,
              "mac": "apdojgaoieg",
              "deviceType": "General Device",
              "createTime": "2019-04-25T23:18:28.423839+08:00",
              "updateTime": "2019-04-25T23:18:28.42384+08:00",
              "remark": "A Test Device",
              "department": "Official 2"
          }
      }

   4. PUT /api/device/{id}  //修改设备信息

      参数说明：同上

      请求示例：PUT /api/device/10

      参数示例：

      {
      	"hardwareDeviceID": "Not the previous Test Device",
      	"deviceName": "Test Device 26",
      	"city": "Nanjing",
      	"factory": "Tongji University",
      	"workshop": "Tongji University",
      	"deviceState": "Error",
      	"imageUrl": "https://www.douyu.com",
      	"gatewayID": 17,
      	"mac": "apdojgaoieg",
      	"deviceType": "General Device",
      	"remark": "A Test Device",
      	"department": "Official 2"
      }

      响应示例：

      {
          "c": 200,
          "m": "success",
          "d": {
              "id": 10,
              "hardwareDeviceID": "Not the previous Test Device",
              "deviceName": "Test Device 26",
              "city": "Nanjing",
              "factory": "Tongji University",
              "workshop": "Tongji University",
              "deviceState": "Error",
              "lastConnectionTime": "2019-04-21T15:37:53+08:00",
              "imageUrl": "https://www.douyu.com",
              "gatewayID": 17,
              "mac": "apdojgaoieg",
              "deviceType": "General Device",
              "createTime": "2019-04-21T15:37:53+08:00",
              "updateTime": "2019-04-25T23:22:03.251123+08:00",
              "remark": "A Test Device",
              "department": "Official 2"
          }
      }

   5. DELETE /api/device/{id}  //删除设备

      请求示例：DELETE /api/device/10

      响应示例：

      {
          "c": 200,
          "m": "success",
          "d": {
              "id": 10,
              "hardwareDeviceID": "Not the previous Test Device",
              "deviceName": "Test Device 26",
              "city": "Nanjing",
              "factory": "Tongji University",
              "workshop": "Tongji University",
              "deviceState": "Error",
              "lastConnectionTime": "2019-04-21T15:37:53+08:00",
              "imageUrl": "https://www.douyu.com",
              "gatewayID": 17,
              "mac": "apdojgaoieg",
              "deviceType": "General Device",
              "createTime": "2019-04-21T15:37:53+08:00",
              "updateTime": "2019-04-25T23:22:03+08:00",
              "remark": "A Test Device",
              "department": "Official 2"
          }
      }
