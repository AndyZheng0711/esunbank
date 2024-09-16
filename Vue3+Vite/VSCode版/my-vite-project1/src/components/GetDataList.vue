<template>
    公司代號：<input type="text" v-model="cCode" />
    <button @click="this.packageGetData">查詢</button>
    <div id="app">
        <table class="table" style="" align="center" border="1" width="100%">
            <thead>
                <tr>
                    <th width="8%">出表日期</th>
                    <th width="8%">資料年月</th>
                    <th width="8%">公司代號</th>
                    <th width="8%">公司名稱</th>
                    <th width="8%">產業別</th>
                    <th width="20%">營業收入</th>
                    <th width="20%">累計營業收入</th>
                    <th width="20%">備註</th>
                </tr>
                <tr v-for="item in result">
                    <td>{{ item.出表日期 }}</td>
                    <td>{{ item.資料年月 }}</td>
                    <td>{{ item.公司代號 }}</td>
                    <td>{{ item.公司名稱 }}</td>
                    <td>{{ item.產業別 }}</td>
                    <td>
                        <p>當月：{{ item.營業收入_當月營收 }}</p>
                        <p>上月：{{ item.營業收入_上月營收 }}</p>
                        <p>去年當月:{{ item.營收收入_去年當月營收 }}</p>
                        <p>增減</p>
                        <p>上月比較:{{ item.營業收入_上月比較增減 }}</p>
                        <p>去年同月:{{ item.營業收入_去年同月增減 }}</p>
                    </td>
                    <td>
                        <p>當月:{{ item.累計營業收入_當月累計營收 }}</p>
                        <p>去年:{{ item.累計營業收入_去年累計營收 }}</p>
                        <p>前期比較:{{ item.累計營業收入_前期比較增減 }}</p>
                    </td>
                    <td>{{ item.備註 }}</td>
                  </tr>
            </thead>
        </table>
        <div align="center">
            當前頁：{{ PageNo }} |
            總頁數：{{ totalPage }} |
            總筆數：{{ totalCount }}
        </div>  
    </div> 
</template>
<script>
import { BusinessList } from "../api/BusinessList";
export default{
    name:'App',
    data(){
        return{
            result:[]
        }
    },
    methods:{
        async packageGetData() {
        // API 位置
        const url = '/GetData';
        console.log(this.cCode);

        // param 設定
        const param = {
            Code: this.cCode,
        }
        
        let res = await BusinessList(param);
        if (res.status)
        {
            this.result = res.data.data;
            this.PageNo = res.data.pageNo;
            this.PageSize = res.data.pageSize;
            this.totalPage = res.data.totalPage;
            this.totalCount = res.data.totalCount;
            console.log(res);
        }
        else
        {
            console.log('error');
        }},
    },
    created() {
        this.packageGetData() // 在created 階段把API資料叫進來
    }
}
</script>