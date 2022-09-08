<template src="./AddNewCountry.template.html" />

<script>
import CountryService from '../services/CountryService'
import { required, minLength, maxLength, alpha, numeric } from 'vuelidate/lib/validators'
import AppHeader from '../Header/components/Header.vue'

const mustBeJpgorPng = value => (value != null && (value.toString().includes('.png') || value.toString().includes('.jpg')))

export default {
  name: 'AddNewCountry',
  components: {
    AppHeader
  },
  data () {
    return {
      countryName: '',
      flag: '',
      base64Image: '',
      rank: '',
      continent: '',
      continents: [],
      fileSize: 0,
      fileSizeError: false,
      apiError: ''
    }
  },
  validations: {
    countryName: {
      alpha,
      required,
      minLength: minLength(3),
      maxLength: maxLength(20)
    },
    flag: {
      required,
      mustBeJpgorPng
    },
    rank: {
      required,
      numeric
    },
    continent: {
      required
    }
  },
  created () {
    this.getAllContinents()
  },
  methods: {
    getAllContinents () {
      CountryService.getContinents()
        .then(response => {
          this.continents = response.data
        })
        .catch(error => console.log(error))
    },
    saveNewCountry () {
      this.$v.$touch()
      this.fileSizeError = this.fileSize > 4096

      if (!this.$v.$invalid && !this.fileSizeError) {
        var country = {
          name: this.countryName,
          continent: this.continent,
          flag: this.base64Image.substr(this.base64Image.indexOf('base64') + 7),
          rank: this.rank
        }
        
        CountryService.AddNewCountry(country)
          .then(response => {
            this.apiError = ''
            this.$swal(
              'Congrats',
              response.data,
              'success'
            )
            this.$router.push('/')
          })
          .catch(error => {
            console.log(error)
            this.apiError = error.response.data != null ? error.response.data : 'Something went wrong'
          })
      }
    },
    getFileSize (event) {
      this.flag = event.target.files[0].name
      this.getFileContentAsBase64(event.target.files[0]).then(base64Image => {
        this.base64Image = base64Image
      })
      this.fileSize = event.target.files[0].size / Math.floor(1024)
    },
    getFileContentAsBase64 (fileURL) {
      return new Promise((resolve, reject) => {
        const reader = new FileReader()
        reader.readAsDataURL(fileURL)
        reader.onload = () => resolve(reader.result)
        reader.onerror = error => reject(error)
      })
    }
  }
}
</script>

<style scoped>
.col-6{
  margin-left: 20px;
}

.row{
  margin-top: 30px;
}
.form-group{
  margin-top: 20px;
}
.md-raised.md-primary{
    margin-top: 40px;
}
.flag{
  margin-top: -300px;
}
</style>
