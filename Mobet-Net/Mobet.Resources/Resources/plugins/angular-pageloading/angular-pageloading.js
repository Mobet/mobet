﻿angular.module("me-pageloading", []).value("mePageLoadingEffects", {
    "Lazy Stretch": {
        opening: "M20,15 50,30 50,30 30,30 Z;M0,0 80,0 50,30 20,45 Z;M0,0 80,0 60,45 0,60 Z;M0,0 80,0 80,60 0,60 Z",
        closing: "M0,0 80,0 60,45 0,60 Z;M0,0 80,0 50,30 20,45 Z;M20,15 50,30 50,30 30,30 Z;M30,30 50,30 50,30 30,30 Z",
        path: "M30,30 50,30 50,30 30,30 Z",
        speedIn: 100
    },
    Circle: {
        opening: "M 40 -21.875 C 11.356078 -21.875 -11.875 1.3560784 -11.875 30 C -11.875 58.643922 11.356078 81.875 40 81.875 C 68.643922 81.875 91.875 58.643922 91.875 30 C 91.875 1.3560784 68.643922 -21.875 40 -21.875 Z",
        path: "M40,30 c 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 Z",
        speedIn: 300,
        easingIn: "easeinout"
    },
    Spill: {
        opening: "M 0,0 c 0,0 63.5,-16.5 80,0 16.5,16.5 0,60 0,60 L 0,60 Z",
        path: "M 0,0 c 0,0 -16.5,43.5 0,60 16.5,16.5 80,0 80,0 L 0,60 Z",
        speedIn: 400,
        easingIn: "easeinout"
    },
    "Frame it": {
        opening: "M 0,0 0,60 80,60 80,0 Z M 40,30 40,30 40,30 40,30 Z",
        path: "M 0,0 0,60 80,60 80,0 Z M 80,0 80,60 0,60 0,0 Z",
        speedIn: 300,
        easingIn: "easeinout"
    },
    "Tunnel vision": {
        opening: "M -18 -26.90625 L -18 86.90625 L 98 86.90625 L 98 -26.90625 L -18 -26.90625 Z M 40 29.96875 C 40.01804 29.96875 40.03125 29.98196 40.03125 30 C 40.03125 30.01804 40.01804 30.03125 40 30.03125 C 39.98196 30.03125 39.96875 30.01804 39.96875 30 C 39.96875 29.98196 39.98196 29.96875 40 29.96875 Z",
        path: "M -18 -26.90625 L -18 86.90625 L 98 86.90625 L 98 -26.90625 L -18 -26.90625 Z M 40 -25.6875 C 70.750092 -25.6875 95.6875 -0.7500919 95.6875 30 C 95.6875 60.750092 70.750092 85.6875 40 85.6875 C 9.2499078 85.6875 -15.6875 60.750092 -15.6875 30 C -15.6875 -0.7500919 9.2499078 -25.6875 40 -25.6875 Z",
        speedIn: 300,
        easingIn: "easeinout"
    },
    "Windscreen wiper": {
        opening: "M 40,100 150,0 -65,0 z",
        path: "M 40,100 150,0 l 0,0 z",
        speedIn: 400,
        easingIn: "easeinout"
    },
    "Jammed blind": {
        opening: "M 0,60 80,60 80,50 0,40 0,60;M 0,60 80,60 80,25 0,40 0,60;M 0,60 80,60 80,25 0,10 0,60;M 0,60 80,60 80,0 0,0 0,60",
        closing: "M 0,60 80,60 80,20 0,0 0,60;M 0,60 80,60 80,20 0,40 0,60;m 0,60 80,0 0,0 -80,0",
        path: "m 0,60 80,0 0,0 -80,0",
        speedIn: 200,
        easingIn: "linear"
    },
    Parallelogram: {
        opening: "M 0,0 0,60 80,60 80,0 z M 80,0 40,30 0,60 40,30 z",
        path: "M 0,0 0,60 80,60 80,0 Z M 80,0 80,60 0,60 0,0 Z",
        speedIn: 300,
        speedOut: 600,
        easingIn: "easeinout",
        easingOut: "bounce"
    },
    Tilted: {
        opening: "M 0,0 80,-10 80,60 0,70 0,0",
        path: "M 0,70 80,60 80,80 0,80 0,70",
        speedIn: 400,
        easingIn: "easeinout"
    },
    "Lateral Swipe": {
        opening: "M 40,-65 145,80 -65,80 40,-65",
        closing: "m 40,-65 0,0 L -65,80 40,-65",
        path: "M 40,-65 145,80 40,-65",
        speedIn: 500,
        easingIn: "easeinout"
    },
    Wave: {
        opening: "m -5,-5 0,70 90,0 0,-70 z m 5,35 c 0,0 15,20 40,0 25,-20 40,0 40,0 l 0,0 C 80,30 65,10 40,30 15,50 0,30 0,30 z",
        path: "m -5,-5 0,70 90,0 0,-70 z m 5,5 c 0,0 7.9843788,0 40,0 35,0 40,0 40,0 l 0,60 c 0,0 -3.944487,0 -40,0 -30,0 -40,0 -40,0 z",
        speedIn: 400,
        easingIn: "easeinout"
    },
    Origami: {
        opening: "m -10,-10 0,80 100,0 0,-80 z m 50,-30.5 0,70.5 0,70 0,-70 z",
        path: "m -10,-10 0,80 100,0 0,-80 z M 40,-40.5 120,30 40,100 -40,30 z",
        speedIn: 400,
        easingIn: "easeinout"
    },
    Curtain: {
        opening: "m 40,-80 190,0 -305,290 C -100,140 0,0 40,-80 z",
        path: "m 75,-80 155,0 0,225 C 90,85 100,30 75,-80 z",
        speedIn: 700,
        easingIn: "easeinout"
    }
}).value("mePageLoadingTemplate", '<div id="pageloader" class="pageload-overlay"><svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%" viewBox="0 0 80 60" preserveAspectRatio="none"><path /></svg></div>').factory("Animater", ["mePageLoadingEffects",
    function (a) {
        function b(a) {
            var b;
            if (this.options = a = angular.extend({
                speedIn: 500,
                easingIn: "linear"
            }, a), !a.el) throw new Error("no el found");
            this.el = a.el, b = Snap(this.el.find("svg")[0]), this.path = b.select("path"), this.effect = a.effect || "random", this.animateOpt = null, this.isAnimating = !1
        }
        return b.prototype.getOpt = function (b) {
            var c, d, e, f, g, h, i, j, k, l, m, n, o;
            return c = b || this.effect, d = Object.keys(a), ("random" === c || d.indexOf(c) < 0) && (c = d[Math.floor(13 * Math.random())]), e = a[c], f = e.path, h = e.opening, g = h ? h.split(";") : "", i = h ? g.length : 0, 0 === i ? !1 : (k = e.closing || f, j = k ? k.split(";") : "", l = k ? j.length : 0, n = e.speedOut || e.speedIn, o = e.easingOut || e.easingIn, m = {
                initialPath: f,
                openingSteps: g,
                openingStepsTotal: i,
                closingSteps: j,
                closingStepsTotal: l,
                speedOut: n,
                easingOut: o,
                speedIn: e.speedIn,
                easingIn: e.easingIn
            })
        }, b.prototype.show = function (a) {
            var b, c = this;
            return c.isAnimating ? !1 : (b = c.getOpt(a), void (b && (c.path.attr("d", b.initialPath), c.animateOpt = b, c.isAnimating = !0, c.animateSVG("in", b, function () {
                c.el.addClass("pageloading-loading")
            }), c.el.addClass("show"))))
        }, b.prototype.hide = function () {
            var a = this,
                b = a.animateOpt;
            return b ? (a.animateOpt = null, a.el.removeClass("pageloading-loading"), void a.animateSVG("out", b, function () {
                a.el.removeClass("show"), a.isAnimating = !1
            })) : !1
        }, b.prototype.animateSVG = function (a, b, c) {
            var d, e = this,
                f = 0,
                g = "out" === a ? b.closingSteps : b.openingSteps,
                h = "out" === a ? b.closingStepsTotal : b.openingStepsTotal,
                i = "out" === a ? b.speedOut : b.speedIn,
                j = "out" === a ? b.easingOut : b.easingIn;
            j = mina[j] || mina.linear, (d = function (a) {
                return a > h - 1 ? void (c && "function" == typeof c && c()) : (e.path.animate({
                    path: g[a]
                }, i, j, function () {
                    d(a)
                }), void a++)
            })(f)
        }, b
    }
]).provider("mePageLoading", function () {
    this.autoPageLoading = !0, this.effect = "random", this.$get = ["mePageLoadingTemplate", "Animater",
        function (a, b) {
            function c(a) {
                h.show(a)
            }

            function d() {
                h.hide()
            }
            var e, f, g, h, i = this;
            return e = i.autoPageLoading, f = document.createElement("div"), f = angular.element(f).html(a), g = f.children(), angular.element(document.body).append(g), h = new b({
                el: g,
                effect: i.effect
            }), {
                show: c,
                hide: d,
                autoPageLoading: e
            }
        }
    ]
}).run(["$rootScope", "mePageLoading",
    function (a, b) {
        if (b.autoPageLoading) {
            var c, d, e, f, g = !1;
            d = function () {
                b.show()
            }, e = f = function () {
                b.hide()
            }, c = function () {
                g || (g = !0, a.$on("$stateChangeStart", d), a.$on("$stateChangeSuccess", e), a.$on("$stateChangeError", f), a.$on("$stateNotFound", f), a.$on("$routeChangeStart", d), a.$on("$routeChangeSuccess", e), a.$on("$routeChangeError", f))
            }, a.$on("$stateChangeSuccess", c), a.$on("$routeChangeSuccess", c)
        }
    }
]);