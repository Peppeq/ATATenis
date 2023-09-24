const path = require("path");

module.exports = {
	configureWebpack: {
		devtool: "source-map"
	},
	pluginOptions: {
		"style-resources-loader": {
			preProcessor: "scss",
			patterns: [path.resolve(__dirname, "./src/styles/global.scss")]
		}
	}
};

const crypto = require('crypto');

/**
 * md4 algorithm is not available anymore in NodeJS 17+ (because of lib SSL 3).
 * In that case, silently replace md4 by md5 algorithm.
 */
try {
  crypto.createHash('md4');
} catch (e) {
  console.warn('Crypto "md4" is not supported anymore by this Node version');
  const origCreateHash = crypto.createHash;
  crypto.createHash = (alg, opts) => {
    return origCreateHash(alg === 'md4' ? 'md5' : alg, opts);
  };
}
// https://stackoverflow.com/questions/69692842/error-message-error0308010cdigital-envelope-routinesunsupported