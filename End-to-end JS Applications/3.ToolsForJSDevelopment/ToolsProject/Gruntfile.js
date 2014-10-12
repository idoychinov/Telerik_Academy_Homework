module.exports = function (grunt) {
	grunt.initConfig({
		project: {
			app: 'app',
			dev: 'dev',
            dist: 'dist'
		},
        coffee : {
            app: {
                files: {'<%= project.dev %>/scripts/app.js' : '<%= project.app %>/scripts/app.coffee'}
        }
        },
		jshint: {
			app: ['Gruntfile.js', '<%= project.dev %>/scripts/**/*.js']
		},
        jade: {
            app: {
                files: {"<%= project.dev %>/index.html": "<%= project.app %>/index.jade"}
            }
        },
		stylus: {
			app: {
				files: {
					'<%= project.dev %>/styles/main.css': '<%= project.app %>/styles/main.styl'
				}
			}
		},
		csslint: {
			app: ['<%= project.dev %>/styles/*.css']
		},
		concat: {
			js: {
				files: {
					'.tmp/concat/scripts/build.js': ['<%= project.dev %>/scripts/**/*.js']
				}
			},
			css: {
				files: {
					'.tmp/concat/styles/build.css': ['<%= project.dev %>/styles/**/*.css']
				}
			}
		},
		uglify: {
			js: {
				files: {
					'.tmp/min/scripts/main.min.js': '.tmp/concat/scripts/main.js'
				}
			}
		},
		cssmin: {
			css: {
				files: {
					'.tmp/min/styles/main.min.css': '.tmp/concat/styles/main.css'
				}
			}
		},
		copy: {
            app : {
                    files: [
                        {expand: true, flatten: true,src: ['app/images/*'], dest: 'dev/images/', filter: 'isFile'}
                    ]
            },
            dev : {
                files: [
                    {expand: true, flatten: true,src: ['dev/images/*'], dest: 'dist/images/', filter: 'isFile'}
                ]
            }
		},
		processhtml: {
			build: {
				files: {
					'<%= project.dist %>/index.html': ['<%= project.dev %>/index.html']
				}
			}
		},
		clean: {
			build: {
				src: ['.tmp', '<%= project.dist %>']
			}
		},
		connect: {
			options: {
				port: 9001,
				livereload: 9578,
				hostname: 'localhost'
			},
			livereload: {
				options: {
					open: true,
					base: [
						'<%= project.dev %>'
					]
				}
			}
		},
		watch: {
			coffee: {
				files: ['Gruntfile.js', '<%= project.app %>/scripts/**/*.coffee'],
				tasks: ['jshint'],
				options: {
					livereload: true
				}
			},
			css: {
				files: ['<%= project.app %>/styles/**/*.styl'],
				tasks: ['stylus', 'csslint'],
				options: {
					livereload: true
				}
			},
			html: {
				files: ['<%= project.app %>/index.html'],
				options: {
					livereload: true
				}
			},
			livereload: {
				options: {
					livereload: '<%= connect.options.livereload %>'
				},
				files: [
					'<%= project.app %>/**/*.jade',
					'<%= project.app %>/**/*.css',
					'<%= project.app %>/**/*.styl'
				]
			}
		}
	});

	grunt.loadNpmTasks('grunt-contrib-jshint');
	grunt.loadNpmTasks('grunt-contrib-csslint');
	grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-cssmin');
	grunt.loadNpmTasks('grunt-processhtml');
	grunt.loadNpmTasks('grunt-contrib-clean');
	grunt.loadNpmTasks('grunt-contrib-connect');
	grunt.loadNpmTasks('grunt-contrib-watch');

	grunt.registerTask('build', ['coffee','jshint', 'jade','stylus', 'csslint', 'clean', 'concat', 'uglify', 'cssmin', 'copy', 'processhtml']);
    grunt.registerTask('serve', ['coffee','jshint','jade','stylus', 'csslint','copy','connect', 'watch']);

};