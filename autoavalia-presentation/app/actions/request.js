import axios from 'axios';
import config from './../../config/json.json'

export function fetchCluster(userId, advertiseId) {
  return axios.get(config.apiPfUrl + 'api/Question/Clusters/' + userId + '/' + advertiseId)
    .then((response) => {
      return response;
    })
    .catch((err) => {
      console.log(err);
    })
}

export function fetchQuestion(userId, advertiseId, cluster){
  return axios.get(config.apiPfUrl + 'api/Question/' + userId + '/' + advertiseId + '/' + cluster)
  .then((response) => {
    return response;
  })
  .catch((err) => {
    console.log(err);
  })
}