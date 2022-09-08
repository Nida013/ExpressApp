import Vue from 'vue'
import Router from 'vue-router'
import GetCountryList from '@/components/GetCountryList/components/GetCountryList'
import AddNewCountry from '@/components/GetCountryList/components/AddNewCountry'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'GetCountryList',
      component: GetCountryList
    },
    {
      path: '/addNewCountry',
      name: 'AddNewCountry',
      component: AddNewCountry
    }
  ]
})
