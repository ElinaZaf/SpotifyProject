<template>
  <b-container fluid>
    <b-row>
      <b-col lg="6">
        <iq-card>
          <template v-slot:headerTitle>
            <h4 class="card-title">Account Setting</h4>
          </template>
          <template v-slot:body>
            <div class="acc-edit">
              <b-form>
                <b-form-group label="User Name:" label-for="uname">
                  <b-form-input id="uname" type="text" value="Barry@01"></b-form-input>
                </b-form-group>
                <b-form-group label="Email Id:" label-for="email">
                  <b-form-input id="email" type="email" value="Barryjohn@gmail.com"></b-form-input>
                </b-form-group>
                <b-form-group label="Alternate Email" label-for="altemail">
                  <b-form-input id="altemail" type="email" value="designtheme@gmail.com"></b-form-input>
                </b-form-group>
                <b-form-group label="Language Known:">
                  <b-form-checkbox v-for="(language,index) of languages" :key="index" v-model="language.checked" inline>{{ language.title }}</b-form-checkbox>
                </b-form-group>
                <b-button type="submit" variant="primary">Submit</b-button>
                <b-button type="submit" variant="none" class="iq-bg-danger">Cancle</b-button>
              </b-form>
            </div>
          </template>
        </iq-card>
      </b-col>
      <b-col lg="6">
        <iq-card>
          <template v-slot:headerTitle>
            <h4 class="card-title">Social Media</h4>
          </template>
          <template v-slot:body>
            <div class="acc-edit">
              <b-form>
                <b-form-group label="Facebook:" label-for="facebook">
                  <b-form-input id="facebook" type="text" value="www.facebook.com"></b-form-input>
                </b-form-group>
                <b-form-group label="Twitter:" label-for="twitter">
                  <b-form-input id="twitter" type="text" value="www.twitter.com"></b-form-input>
                </b-form-group>
                <b-form-group label="Google +:" label-for="google">
                  <b-form-input id="google" type="text" value="www.google.com"></b-form-input>
                </b-form-group>
                <b-form-group label="Instagram:" label-for="instagram">
                  <b-form-input id="instagram" type="text" value="www.instagram.com"></b-form-input>
                </b-form-group>
                <b-form-group label="You Tube:" label-for="youtube">
                  <b-form-input id="youtube" type="text" value="www.youtube.com"></b-form-input>
                </b-form-group>
                <b-button type="submit" variant="primary">Submit</b-button>
                <b-button type="submit" variant="none" class="iq-bg-danger">Cancle</b-button>
              </b-form>
            </div>
          </template>
        </iq-card>
      </b-col>
    </b-row>
  </b-container>
</template>
<script>
import { core } from '../../config/pluginInit'

export default {
  name: 'AccountSettings',
  mounted () {
    core.index()
  },
  data () {
    return {
      languages: [
        { title: 'English', checked: true },
        { title: 'French', checked: true },
        { title: 'Hindi', checked: false },
        { title: 'Spanish', checked: true },
        { title: 'Arabic', checked: false },
        { title: 'Italian', checked: false }
      ]
    }
  }
}
</script>
