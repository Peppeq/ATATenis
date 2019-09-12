module.exports = {
	parserOptions: {
		parser: "@typescript-eslint/parser"
	},
	extends: [
		"plugin:@typescript-eslint/recommended", // Uses the recommended rules from the @typescript-eslint/eslint-plugin
		"plugin:vue/recommended",
		"prettier/vue",
		"prettier/@typescript-eslint", // Uses eslint-config-prettier to disable ESLint rules from @typescript-eslint/eslint-plugin that would conflict with prettier
		"plugin:prettier/recommended" // Enables eslint-plugin-prettier and eslint-config-prettier. This will display prettier errors as ESLint errors. Make sure this is always the last configuration in the extends array.
	],
	plugins: ["@typescript-eslint"],
	rules: {
		"vue/max-attributes-per-line": "off",
		"vue/singleline-html-element-content-newline": "off",
		"vue/component-name-in-template-casing": ["error", "PascalCase"],
		indent: "off",
		"@typescript-eslint/indent": ["error", "tab"],
		printWidth: 100,
		"no-console": "off",
		"no-debugger": "off",
		"prettier/prettier": [
			"error",
			{
				singleQuote: false,
				useTabs: true,
				tabWidth: 4,
				printWidth: 120
			}
		]
	},
	"overrides": [
        {
			"files": ["**/*.js", "**/*.jsx"],
			"plugins": [ "@typescript-eslint" ],
            "rules": {
				"@typescript-eslint/recommended": "off",
				"@typescript-eslint/indent": "off"
            }
        }
    ]
};
