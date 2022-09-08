<template src="./GetCountryList.template.html" />

<script>
import CountryService from '../services/CountryService'
import AppHeader from '../Header/components/Header.vue'

export default {
  name: 'HelloWorld',
  data () {
    return {
      getCountries: null,
      currentValue: 'Australia',
      getCountry: null
    }
  },
  components: {
    AppHeader
  },
  created () {
    this.getCountryList()
  },
  methods: {
    navigateToAddNewCountry () {
      this.$router.push('/addNewCountry')
    },
    getCountryList () {
      CountryService.getCountryList()
        .then(response => {
          this.getCountries = response.data
          this.getCountry = this.getCountries.countries.filter(x => x.name === this.currentValue)[0]
        })
        .catch(error => console.log(error))
    },
    getCountryById (countryId) {
      CountryService.getCountry(countryId)
        .then(response => {
          this.getCountry = response.data
        })
        .catch(error => console.log(error))
    },
    getCurrentCountryData (currentValue) {
      var getSelectedCountryInfo = this.getCountries.countries.filter(x => x.name === currentValue)
      this.getCountry = getSelectedCountryInfo[0]
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.md-card{
  margin-top: 100px;
}
.nameSize{
  margin-right: 30%;
  font-size: x-large;
}
</style>
