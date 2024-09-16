import { http } from '../utils/http'

/**
 * axios 的 data方式传参适用于post方式请求数据
 * 查询传参的内容，打开浏览器查看发送请求头的内容
 * 查询名字的相关内容
 * @param params 
 */
export function GetDataList(params:any) {
    return http({
        url: '/api/GetData',
        method: 'post',
        params,
    })
}


