const {RealtyRequest, RealtyResponse} = require('./proto/DowntownRealty_pb.js');
const {DowntownRealtyClient} = require('./proto/DowntownRealty_grpc_web_pb.js');

//var realtyServiceClient = new DowntownRealtyClient('http://localhost:8080');
let realtyServiceClient = new DowntownRealtyClient('https://localhost:5001');
console.log(window.location.origin);

let request = new RealtyRequest();
request.setId(22);

realtyServiceClient.getRealtyById(request, {}, function(err, response) {
  document.getElementById('inputWindow').innerHTML = response;
    console.log(response);
});