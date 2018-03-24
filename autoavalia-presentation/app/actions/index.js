import axios from 'axios';
import config from './../../config/config.json'

export function fetchCluster(userId, advertiseId, callback) {
  return axios.get(config.api + 'api/Questionnaire/' + userId + '/' + advertiseId)
    .then((response) => {
      callback(response);
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchQuestion(userId, advertiseId, cluster) {
  return axios.get(config.api + 'api/Question/' + userId + '/' + advertiseId + '/' + cluster)
    .then((response) => {
      return response;
    })
    .catch((err) => {
      console.log(err);
    })
}

