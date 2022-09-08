import axios from 'axios'

export default {
  getCountryList () {
    const url = 'https://localhost:7054/ExpressApp/GetCountriesDetails'
    const getRequestConfig = {
      method: 'get',
      url: url
    }
    return axios(getRequestConfig)
  },
  getCountry (countryId) {
    const url = 'https://localhost:7054/ExpressApp/GetCountryByCountryId/GetCountryByCountryId/' + countryId
    const getRequestConfig = {
      method: 'get',
      url: url
    }
    return axios(getRequestConfig)
  },
  getContinents () {
    const url = 'https://localhost:7054/ExpressApp/GetContinents'
    const getRequestConfig = {
      method: 'get',
      url: url
    }
    return axios(getRequestConfig)
  },
  AddNewCountry (country) {
    const url = 'https://localhost:7054/ExpressApp/AddCountry'
    const postRequestConfig = {
      method: 'post',
      url: url,
      data: country
    }
    return axios(postRequestConfig)
  }

}
