module.exports = {
  parser: '@typescript-eslint/parser',
  extends: [
    'airbnb-typescript/base',
    'plugin:@typescript-eslint/recommended',
    'plugin:react/recommended',
  ],
  plugins: ['@typescript-eslint', 'react'],
  parserOptions: {
    project: ['./tsconfig.json'],
    ecmaVersion: 2018,
    sourceType: 'module',
    ecmaFeatures: {},
  },
  rules: {
    'import/extensions': 0,
    // e.g. "@typescript-eslint/explicit-function-return-type": "off",
  },
  settings: {
    react: {
      version: 'detect',
    },
  },
};
