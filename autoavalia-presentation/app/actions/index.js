import axios from 'axios';
import config from './../../config/config.json'

export function fetchCluster(userId, advertiseId) {
  console.log(config);
  return axios.get(config.api + 'api/Clusters/' + userId + '/' + advertiseId)
    .then((response) => {
      return response;
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

