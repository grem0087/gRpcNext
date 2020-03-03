const {RealtyRequest, RealtyResponse} = require('./proto/DowntownRealty.js');
const {DowntownRealtyClient} = require('./proto/DowntownRealty_grpc_web_pb.js');

var realtyService = new DowntownRealtyClient('http://localhost:8080');

var request = new RealtyRequest();
request.setMessage(22);

realtyService.echo(request, {}, function(err, response) {
  // ...
});