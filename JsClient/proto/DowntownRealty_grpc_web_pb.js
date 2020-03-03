/**
 * @fileoverview gRPC-Web generated client stub for 
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!



const grpc = {};
grpc.web = require('grpc-web');

const proto = require('./DowntownRealty_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.DowntownRealtyClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.DowntownRealtyPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.RealtyRequest,
 *   !proto.RealtyResponse>}
 */
const methodDescriptor_DowntownRealty_GetRealtyById = new grpc.web.MethodDescriptor(
  '/DowntownRealty/GetRealtyById',
  grpc.web.MethodType.UNARY,
  proto.RealtyRequest,
  proto.RealtyResponse,
  /**
   * @param {!proto.RealtyRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.RealtyResponse.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.RealtyRequest,
 *   !proto.RealtyResponse>}
 */
const methodInfo_DowntownRealty_GetRealtyById = new grpc.web.AbstractClientBase.MethodInfo(
  proto.RealtyResponse,
  /**
   * @param {!proto.RealtyRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.RealtyResponse.deserializeBinary
);


/**
 * @param {!proto.RealtyRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.RealtyResponse)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.RealtyResponse>|undefined}
 *     The XHR Node Readable Stream
 */
proto.DowntownRealtyClient.prototype.getRealtyById =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/DowntownRealty/GetRealtyById',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetRealtyById,
      callback);
};


/**
 * @param {!proto.RealtyRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.RealtyResponse>}
 *     A native promise that resolves to the response
 */
proto.DowntownRealtyPromiseClient.prototype.getRealtyById =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/DowntownRealty/GetRealtyById',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetRealtyById);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.RealtyListRequest,
 *   !proto.RealtyListResponse>}
 */
const methodDescriptor_DowntownRealty_GetRealtyList = new grpc.web.MethodDescriptor(
  '/DowntownRealty/GetRealtyList',
  grpc.web.MethodType.UNARY,
  proto.RealtyListRequest,
  proto.RealtyListResponse,
  /**
   * @param {!proto.RealtyListRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.RealtyListResponse.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.RealtyListRequest,
 *   !proto.RealtyListResponse>}
 */
const methodInfo_DowntownRealty_GetRealtyList = new grpc.web.AbstractClientBase.MethodInfo(
  proto.RealtyListResponse,
  /**
   * @param {!proto.RealtyListRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.RealtyListResponse.deserializeBinary
);


/**
 * @param {!proto.RealtyListRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.RealtyListResponse)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.RealtyListResponse>|undefined}
 *     The XHR Node Readable Stream
 */
proto.DowntownRealtyClient.prototype.getRealtyList =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/DowntownRealty/GetRealtyList',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetRealtyList,
      callback);
};


/**
 * @param {!proto.RealtyListRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.RealtyListResponse>}
 *     A native promise that resolves to the response
 */
proto.DowntownRealtyPromiseClient.prototype.getRealtyList =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/DowntownRealty/GetRealtyList',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetRealtyList);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.UserRequest,
 *   !proto.UserResponse>}
 */
const methodDescriptor_DowntownRealty_GetUserById = new grpc.web.MethodDescriptor(
  '/DowntownRealty/GetUserById',
  grpc.web.MethodType.UNARY,
  proto.UserRequest,
  proto.UserResponse,
  /**
   * @param {!proto.UserRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.UserResponse.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.UserRequest,
 *   !proto.UserResponse>}
 */
const methodInfo_DowntownRealty_GetUserById = new grpc.web.AbstractClientBase.MethodInfo(
  proto.UserResponse,
  /**
   * @param {!proto.UserRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.UserResponse.deserializeBinary
);


/**
 * @param {!proto.UserRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.Error, ?proto.UserResponse)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.UserResponse>|undefined}
 *     The XHR Node Readable Stream
 */
proto.DowntownRealtyClient.prototype.getUserById =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/DowntownRealty/GetUserById',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetUserById,
      callback);
};


/**
 * @param {!proto.UserRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.UserResponse>}
 *     A native promise that resolves to the response
 */
proto.DowntownRealtyPromiseClient.prototype.getUserById =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/DowntownRealty/GetUserById',
      request,
      metadata || {},
      methodDescriptor_DowntownRealty_GetUserById);
};


module.exports = proto;

