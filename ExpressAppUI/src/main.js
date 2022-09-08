// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import 'bootstrap/dist/css/bootstrap.css'
import {
  MdButton,
  MdCard,
  MdIcon,
  MdRipple,
  MdField,
  MdCheckbox,
  MdMenu,
  MdList,
  MdSwitch,
  MdHighlightText,
  MdDialog,
  MdDialogAlert,
  MdDialogConfirm,
  MdTabs
} from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import Vuelidate from 'vuelidate'
import VueSweetalert2 from 'vue-sweetalert2'

// If you don't need the styles, do not connect
import 'sweetalert2/dist/sweetalert2.min.css'

Vue.use(VueSweetalert2)
Vue.config.productionTip = false
Vue.use(VueAxios, axios)
Vue.use(MdCard)
Vue.use(MdButton)
Vue.use(MdIcon)
Vue.use(MdRipple)
Vue.use(MdField)
Vue.use(MdCheckbox)
Vue.use(MdDialog)
Vue.use(MdDialogAlert)
Vue.use(MdDialogConfirm)
Vue.use(Vuelidate)
Vue.use(MdMenu)
Vue.use(MdList)
Vue.use(MdSwitch)
Vue.use(MdHighlightText)
Vue.use(MdTabs)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
