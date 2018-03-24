import axios from 'axios';
import config from './../../config/config.json'

export function fetchQuestionnaire(userId, advertiseId, callback) {
  return axios.get(config.api + 'api/Questionnaire/' + userId + '/' + advertiseId)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

